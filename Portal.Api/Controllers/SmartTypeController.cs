using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portal.Api.Data;
using ViewModels.Dtos;

namespace Portal.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SmartTypeController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public SmartTypeController(ApplicationDbContext context) => _context = context;

    /// <summary>
    /// Get a SmartType with all its codes by name.
    /// Used to populate dropdowns (Pronouns, GenderIdentity, SexualIdentity, etc.)
    /// </summary>
    [AllowAnonymous]
    [HttpGet]
    [ProducesResponseType(typeof(SmartTypeDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<SmartTypeDto>> GetByName([FromQuery] string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return BadRequest(new { message = "name query parameter is required" });

        var smartType = await _context.SmartTypes
            .Include(t => t.SmartCodes)
            .FirstOrDefaultAsync(t => t.Name == name);

        if (smartType == null)
            return NotFound(new { message = $"SmartType '{name}' not found" });

        var dto = new SmartTypeDto
        {
            Id = smartType.Id,
            Name = smartType.Name,
            SmartCodes = smartType.SmartCodes
                .OrderBy(c => c.Order)
                .Select(c => new SmartCodeDto
                {
                    Id = c.Id,
                    Code = c.Code ?? string.Empty,
                    Label = c.Label,
                    Order = c.Order,
                })
                .ToList(),
        };

        return Ok(dto);
    }
}
