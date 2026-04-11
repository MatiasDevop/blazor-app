using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Requests.Endpoints.Connections;
using ViewModels.Dtos;

namespace Portal.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ConnectionsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ConnectionsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Send a connection request to another user - Requires authentication
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(CreateConnectionResult), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<CreateConnectionResult>> CreateConnection(
        [FromQuery] Guid requesterId,
        [FromQuery] Guid recipientId)
    {
        var request = new CreateConnectionRequest(Guid.NewGuid(), requesterId, recipientId);
        var result = await _mediator.Send(request);

        if (!result.Success)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }

    /// <summary>
    /// Accept a pending connection request - Requires authentication
    /// </summary>
    [HttpPut("{connectionId:guid}/accept")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> AcceptConnection(Guid connectionId, [FromQuery] Guid approverId)
    {
        var request = new AcceptConnectionRequest(Guid.NewGuid(), connectionId, approverId);
        var result = await _mediator.Send(request);

        return Ok(new { message = result.Message, success = result.Success });
    }

    /// <summary>
    /// Decline a connection request - Requires authentication
    /// </summary>
    [HttpDelete("{connectionId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeclineConnection(Guid connectionId, [FromQuery] Guid userId)
    {
        var request = new DeclineConnectionRequest(Guid.NewGuid(), connectionId, userId);
        var result = await _mediator.Send(request);

        return Ok(new { message = result.Message, success = result.Success });
    }

    /// <summary>
    /// Get all connections for a user, optionally filtered by status - Requires authentication
    /// </summary>
    [HttpGet("user/{userId:guid}")]
    [ProducesResponseType(typeof(List<UserConnectionDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<List<UserConnectionDto>>> GetUserConnections(
        Guid userId,
        [FromQuery] string? status = null)
    {
        var request = new GetUserConnectionsRequest(Guid.NewGuid(), userId, status);
        var result = await _mediator.Send(request);

        return Ok(result.Connections);
    }
}
