using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portal.Api.Data;
using System.Security.Claims;
using ViewModels.Dtos;
using ViewModels.Requests.Endpoints.Connections;

namespace Portal.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UserConnectionController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ApplicationDbContext _context;

    public UserConnectionController(IMediator mediator, ApplicationDbContext context)
    {
        _mediator = mediator;
        _context = context;
    }

    private async Task<Guid?> GetCurrentUserIdAsync()
    {
        var email = User.FindFirst(ClaimTypes.Email)?.Value
            ?? User.FindFirst("email")?.Value
            ?? User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(email))
            return null;

        var profile = await _context.UserProfiles
            .Where(u => u.Email == email)
            .Select(u => (Guid?)u.Id)
            .FirstOrDefaultAsync();

        return profile;
    }

    /// <summary>
    /// Get pending connections for the current user
    /// </summary>
    [HttpGet("Pending")]
    [ProducesResponseType(typeof(List<UserConnectionDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<UserConnectionDto>>> GetPending()
    {
        var userId = await GetCurrentUserIdAsync();
        if (userId == null) return Unauthorized();

        var request = new GetUserConnectionsRequest(Guid.NewGuid(), userId.Value, "Pending");
        var result = await _mediator.Send(request);

        return Ok(result.Connections);
    }

    /// <summary>
    /// Send a connection request to another user
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(CreateConnectionResult), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> CreateConnection([FromBody] UserConnectionDto dto)
    {
        var requesterId = await GetCurrentUserIdAsync();
        if (requesterId == null) return Unauthorized();

        var request = new CreateConnectionRequest(Guid.NewGuid(), requesterId.Value, dto.UserId);
        var result = await _mediator.Send(request);

        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }

    /// <summary>
    /// Accept a pending connection request
    /// </summary>
    [HttpPatch("{id:guid}/Accept")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> AcceptConnection(Guid id)
    {
        var userId = await GetCurrentUserIdAsync();
        if (userId == null) return Unauthorized();

        var request = new AcceptConnectionRequest(Guid.NewGuid(), id, userId.Value);
        var result = await _mediator.Send(request);

        return Ok(new { message = result.Message, success = result.Success });
    }

    /// <summary>
    /// Decline a connection request
    /// </summary>
    [HttpPatch("{id:guid}/Decline")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeclineConnection(Guid id)
    {
        var userId = await GetCurrentUserIdAsync();
        if (userId == null) return Unauthorized();

        var request = new DeclineConnectionRequest(Guid.NewGuid(), id, userId.Value);
        var result = await _mediator.Send(request);

        return Ok(new { message = result.Message, success = result.Success });
    }

    /// <summary>
    /// Remove a connection
    /// </summary>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteConnection(Guid id)
    {
        var userId = await GetCurrentUserIdAsync();
        if (userId == null) return Unauthorized();

        var request = new DeclineConnectionRequest(Guid.NewGuid(), id, userId.Value);
        var result = await _mediator.Send(request);

        return Ok(new { message = result.Message, success = result.Success });
    }
}
