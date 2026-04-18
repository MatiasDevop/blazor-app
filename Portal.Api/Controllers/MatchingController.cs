using Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portal.Api.Data;
using System.Security.Claims;
using ViewModels.Dtos;
using ViewModels.Queries;

namespace Portal.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MatchingController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<MatchingController> _logger;

    public MatchingController(ApplicationDbContext context, ILogger<MatchingController> logger)
    {
        _context = context;
        _logger = logger;
    }

    /// <summary>
    /// Get potential connection matches for the current user.
    /// Returns mentor-seekers (Mentoring) or mentors (Assisting) depending on query.Type.
    /// </summary>
    [Authorize]
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<PotentialConnectionDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<PotentialConnectionDto>>> GetMatches([FromQuery] SearchMatchesQuery query)
    {
        var email = User.FindFirst(ClaimTypes.Email)?.Value
                    ?? User.FindFirst("email")?.Value
                    ?? User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        var currentUser = await _context.UserProfiles
            .FirstOrDefaultAsync(u => u.Email.ToLower() == email!.ToLower());

        if (currentUser == null)
            return Ok(Enumerable.Empty<PotentialConnectionDto>());

        // Return users of complementary type based on Mentoring/Assisting
        var targetType = query.Type == UserConnectionType.Mentoring
            ? ProfileType.Mentor
            : ProfileType.Student;

        var potentialMatches = await _context.UserProfiles
            .Where(u => u.Id != currentUser.Id && u.ProfileType == targetType)
            .OrderByDescending(u => u.CreatedAt)
            .Skip(query.Skip)
            .Take(query.Count > 0 ? query.Count : 10)
            .Select(u => new PotentialConnectionDto
            {
                Id = u.Id,
                UserId = u.Id,
                Type = query.Type,
                Score = 50,
            })
            .ToListAsync();

        return Ok(potentialMatches);
    }

    /// <summary>
    /// Decline a potential connection match.
    /// </summary>
    [Authorize]
    [HttpPatch("{id:guid}/Decline")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeclineMatch(Guid id)
    {
        var match = await _context.PotentialConnections.FindAsync(id);
        if (match == null)
            return NotFound(new { message = $"Match {id} not found" });

        _context.PotentialConnections.Remove(match);
        await _context.SaveChangesAsync();
        return Ok();
    }
}
