using MediatR;
using Microsoft.EntityFrameworkCore;
using Portal.Api.Data;
using ViewModels.Requests.Endpoints.Connections;

namespace Portal.Api.Handlers.Connections;

public class DeclineConnectionHandler : IRequestHandler<DeclineConnectionRequest, DeclineConnectionResult>
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<DeclineConnectionHandler> _logger;

    public DeclineConnectionHandler(ApplicationDbContext context, ILogger<DeclineConnectionHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<DeclineConnectionResult> Handle(DeclineConnectionRequest request, CancellationToken cancellationToken)
    {
        var connection = await _context.UserConnections
            .FirstOrDefaultAsync(c => c.Id == request.ConnectionId, cancellationToken);

        if (connection == null)
        {
            _logger.LogWarning("Connection {ConnectionId} not found", request.ConnectionId);
            throw new KeyNotFoundException($"Connection with ID {request.ConnectionId} not found");
        }

        // Verify that the user is either the requester or recipient
        if (connection.RequesterId != request.UserId && connection.RecipientId != request.UserId)
        {
            _logger.LogWarning("User {UserId} is not authorized to decline connection {ConnectionId}",
                request.UserId, request.ConnectionId);
            throw new UnauthorizedAccessException("You are not authorized to decline this connection request");
        }

        // Remove the connection
        _context.UserConnections.Remove(connection);
        await _context.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("Connection {ConnectionId} declined by {UserId}",
            request.ConnectionId, request.UserId);

        return new DeclineConnectionResult(
            request.RequestId,
            true,
            "Connection request declined successfully");
    }
}
