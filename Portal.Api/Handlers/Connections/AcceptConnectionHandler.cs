using MediatR;
using Microsoft.EntityFrameworkCore;
using Portal.Api.Data;
using ViewModels.Requests.Endpoints.Connections;

namespace Portal.Api.Handlers.Connections;

public class AcceptConnectionHandler : IRequestHandler<AcceptConnectionRequest, AcceptConnectionResult>
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<AcceptConnectionHandler> _logger;

    public AcceptConnectionHandler(ApplicationDbContext context, ILogger<AcceptConnectionHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<AcceptConnectionResult> Handle(AcceptConnectionRequest request, CancellationToken cancellationToken)
    {
        var connection = await _context.UserConnections
            .FirstOrDefaultAsync(c => c.Id == request.ConnectionId, cancellationToken);

        if (connection == null)
        {
            _logger.LogWarning("Connection {ConnectionId} not found", request.ConnectionId);
            throw new KeyNotFoundException($"Connection with ID {request.ConnectionId} not found");
        }

        // Verify that the approver is the recipient of the connection request
        if (connection.RecipientId != request.ApproverId)
        {
            _logger.LogWarning("User {ApproverId} is not authorized to accept connection {ConnectionId}",
                request.ApproverId, request.ConnectionId);
            throw new UnauthorizedAccessException("You are not authorized to accept this connection request");
        }

        // Check if already accepted
        if (connection.Status == "Approved")
        {
            return new AcceptConnectionResult(
                request.RequestId,
                true,
                "Connection is already approved");
        }

        // Update connection status
        connection.Status = "Approved";
        connection.DateApproved = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("Connection {ConnectionId} accepted by {ApproverId}",
            request.ConnectionId, request.ApproverId);

        return new AcceptConnectionResult(
            request.RequestId,
            true,
            "Connection request accepted successfully");
    }
}
