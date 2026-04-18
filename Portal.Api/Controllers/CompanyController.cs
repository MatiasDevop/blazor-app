using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portal.Api.Data;
using ViewModels.Dtos;

namespace Portal.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CompanyController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<CompanyController> _logger;

    public CompanyController(ApplicationDbContext context, ILogger<CompanyController> logger)
    {
        _context = context;
        _logger = logger;
    }

    /// <summary>
    /// Get a company claim (full profile) by its claim ID.
    /// </summary>
    [AllowAnonymous]
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(FullCompanyDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<FullCompanyDto>> GetCompany(Guid id)
    {
        var claim = await _context.CompanyClaims
            .Include(c => c.CompanyProfile)
            .Include(c => c.Address)
                .ThenInclude(a => a.State)
            .Include(c => c.OrganizationSize)
            .FirstOrDefaultAsync(c => c.Id == id || c.CompanyProfileId == id);

        if (claim == null)
            return NotFound(new { message = $"Company {id} not found" });

        var dto = new FullCompanyDto
        {
            Id = claim.Id,
            ClaimOwnerId = claim.UserProfileId ?? Guid.Empty,
            Website = claim.Website ?? string.Empty,
            Email = claim.Email ?? string.Empty,
            Description = claim.Description ?? string.Empty,
            VideoUrl = claim.VideoUrl ?? string.Empty,
            AffinityGroupName = claim.AffinityGroupName ?? string.Empty,
            ClaimIsActive = true,
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
            CompanyProfile = claim.CompanyProfile != null ? new CompanyDto
            {
                Name = claim.CompanyProfile.Name,
            } : null,
            MultiSelections = new Dictionary<string, List<SmartCodeDto>>(),
            SocialLinks = new List<SocialLinkDto>(),
            Documents = new List<PartialCompanyDocumentDto>(),
            Majors = new List<EducationFocusDto>(),
            AcceptedWorkAuthorizations = new List<CompanyWorkAuthorizationDto>(),
            Employees = new List<ViewModels.ViewModels.EmployeeVm>(),
        };

        return Ok(dto);
    }

    /// <summary>
    /// Get spotlight companies for the landing page (most recently added).
    /// </summary>
    [AllowAnonymous]
    [HttpGet("{count:int}")]
    [ProducesResponseType(typeof(IEnumerable<CompanyDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<CompanyDto>>> GetSpotlightCompanies(int count = 4)
    {
        var companies = await _context.CompanyProfiles
            .OrderByDescending(c => c.CreatedAt)
            .Take(count)
            .Select(c => new CompanyDto
            {
                Name = c.Name,
            })
            .ToListAsync();

        return Ok(companies);
    }

    /// <summary>
    /// Search companies by name.
    /// </summary>
    [AllowAnonymous]
    [HttpGet("search")]
    [ProducesResponseType(typeof(IEnumerable<CompanyProfileDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<CompanyProfileDto>>> SearchCompanies([FromQuery] string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Ok(Enumerable.Empty<CompanyProfileDto>());

        var results = await _context.CompanyProfiles
            .Where(c => c.Name.ToLower().Contains(name.ToLower()))
            .Take(20)
            .Select(c => new CompanyProfileDto
            {
                Id = c.Id,
                Name = c.Name,
            })
            .ToListAsync();

        return Ok(results);
    }

    /// <summary>
    /// Get company logo as base64.
    /// </summary>
    [AllowAnonymous]
    [HttpGet("{id:guid}/Logo")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetLogo(Guid id)
    {
        // Logo storage not yet implemented - return 404 so the client falls back to placeholder
        return NotFound();
    }

    /// <summary>
    /// Update company logo.
    /// </summary>
    [Authorize]
    [HttpPut("{id:guid}/Logo")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult UpdateLogo(Guid id, [FromBody] AttachmentDto attachment)
    {
        // Logo storage not yet implemented
        return Ok();
    }
}
