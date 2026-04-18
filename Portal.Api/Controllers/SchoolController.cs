using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portal.Api.Data;
using ViewModels.Dtos;
using ViewModels.ViewModels;

namespace Portal.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SchoolController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<SchoolController> _logger;

    public SchoolController(ApplicationDbContext context, ILogger<SchoolController> logger)
    {
        _context = context;
        _logger = logger;
    }

    /// <summary>
    /// Get a career center (school claim) by school claim ID or school ID.
    /// </summary>
    [AllowAnonymous]
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(FullCareerCenterDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<FullCareerCenterDto>> GetCareerCenter(Guid id)
    {
        var claim = await _context.SchoolClaims
            .Include(s => s.School)
            .Include(s => s.Address)
                .ThenInclude(a => a.State)
            .Include(s => s.InstitutionType)
            .Include(s => s.OrganizationSize)
            .Include(s => s.SocialLinks)
            .FirstOrDefaultAsync(s => s.Id == id || s.SchoolId == id);

        if (claim == null)
            return NotFound(new { message = $"Career center {id} not found" });

        var dto = new FullCareerCenterDto
        {
            Id = claim.Id,
            ClaimOwnerId = claim.UserProfile?.Id ?? Guid.Empty,
            CareerCenterName = claim.CareerCenterName ?? claim.School?.Name ?? string.Empty,
            WhoWeAre = claim.WhoWeAre ?? string.Empty,
            Website = claim.Website ?? string.Empty,
            Email = claim.Email ?? string.Empty,
            VideoUrl = claim.VideoUrl ?? string.Empty,
            InstitutionType = claim.InstitutionType != null ? new SmartCodeDto
            {
                Id = claim.InstitutionType.Id,
                Code = claim.InstitutionType.Code ?? string.Empty,
                Label = claim.InstitutionType.Label,
                Order = claim.InstitutionType.Order,
            } : null,
            OrganizationSize = claim.OrganizationSize != null ? new SmartCodeDto
            {
                Id = claim.OrganizationSize.Id,
                Code = claim.OrganizationSize.Code ?? string.Empty,
                Label = claim.OrganizationSize.Label,
                Order = claim.OrganizationSize.Order,
            } : null,
            Address = claim.Address != null ? new FullAddressDto
            {
                Line1 = claim.Address.Line1 ?? string.Empty,
                City = claim.Address.City ?? string.Empty,
                ZipCode = claim.Address.ZipCode ?? claim.Address.PostalCode ?? string.Empty,
                State = claim.Address.State != null ? new SmartCodeDto
                {
                    Id = claim.Address.State.Id,
                    Code = claim.Address.State.Code ?? string.Empty,
                    Label = claim.Address.State.Label,
                    Order = claim.Address.State.Order,
                } : null,
            } : null,
            School = claim.School != null ? new SchoolDto
            {
                Id = claim.School.Id,
                UniversityName = claim.School.UniversityName ?? claim.School.Name,
                CollegeName = claim.School.CollegeName ?? string.Empty,
            } : null,
            SocialLinks = claim.SocialLinks?.Select(s => new SocialLinkDto
            {
                Id = s.Id,
                Url = s.Url,
            }).ToList() ?? new List<SocialLinkDto>(),
            Documents = new List<PartialCareerCenterDocumentDto>(),
            Employees = new List<EmployeeVm>(),
        };

        return Ok(dto);
    }

    /// <summary>
    /// Get spotlight career-center schools for the landing page.
    /// </summary>
    [AllowAnonymous]
    [HttpGet("{count:int}")]
    [ProducesResponseType(typeof(IEnumerable<CareerCenterCardViewModel>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<CareerCenterCardViewModel>>> GetSpotlightSchools(int count = 4)
    {
        var schools = await _context.Schools
            .OrderByDescending(s => s.CreatedAt)
            .Take(count)
            .Select(s => new CareerCenterCardViewModel
            {
                Name = s.DisplayName ?? s.Name,
            })
            .ToListAsync();

        return Ok(schools);
    }

    /// <summary>
    /// Search schools by name.
    /// </summary>
    [AllowAnonymous]
    [HttpGet("search")]
    [ProducesResponseType(typeof(IEnumerable<SchoolDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<SchoolDto>>> SearchSchools([FromQuery] string name, [FromQuery] bool excludeChildren = false)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Ok(Enumerable.Empty<SchoolDto>());

        var results = await _context.Schools
            .Where(s => s.Name.ToLower().Contains(name.ToLower())
                        || (s.DisplayName != null && s.DisplayName.ToLower().Contains(name.ToLower())))
            .Take(20)
            .Select(s => new SchoolDto
            {
                Id = s.Id,
                UniversityName = s.UniversityName ?? s.Name,
                CollegeName = s.CollegeName ?? string.Empty,
            })
            .ToListAsync();

        return Ok(results);
    }

    /// <summary>
    /// Get school logo. Returns 404 until binary storage is implemented.
    /// </summary>
    [AllowAnonymous]
    [HttpGet("{id:guid}/Logo")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetLogo(Guid id) => NotFound();
}
