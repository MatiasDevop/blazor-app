using MediatR;
using Microsoft.EntityFrameworkCore;
using Portal.Api.Data;
using Domain.Entities;
using ViewModels.Requests.Endpoints.Connections;

namespace Portal.Api.Handlers.Connections;

public class CreateConnectionHandler : IRequestHandler<CreateConnectionRequest, CreateConnectionResult>
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<CreateConnectionHandler> _logger;

    public CreateConnectionHandler(ApplicationDbContext context, ILogger<CreateConnectionHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<CreateConnectionResult> Handle(CreateConnectionRequest request, CancellationToken cancellationToken)
    {
        // Validate that requester and recipient exist
        var requester = await _context.UserProfiles.FindAsync(new object[] { request.RequesterId }, cancellationToken);
        if (requester == null)
        {
            _logger.LogWarning("Requester {RequesterId} not found", request.RequesterId);
            throw new KeyNotFoundException($"Requester with ID {request.RequesterId} not found");
        }

        var recipient = await _context.UserProfiles.FindAsync(new object[] { request.RecipientId }, cancellationToken);
        if (recipient == null)
        {
            _logger.LogWarning("Recipient {RecipientId} not found", request.RecipientId);
            throw new KeyNotFoundException($"Recipient with ID {request.RecipientId} not found");
        }

        // Check if connection already exists
        var existingConnection = await _context.UserConnections
            .FirstOrDefaultAsync(c =>
                (c.RequesterId == request.RequesterId && c.RecipientId == request.RecipientId) ||
                (c.RequesterId == request.RecipientId && c.RecipientId == request.RequesterId),
                cancellationToken);

        if (existingConnection != null)
        {
            _logger.LogInformation("Connection already exists between {RequesterId} and {RecipientId}",
                request.RequesterId, request.RecipientId);
            return new CreateConnectionResult(
                request.RequestId,
                false,
                "Connection request already exists");
        }

        // Create new connection request
        var connection = new UserConnection
        {
            Id = Guid.NewGuid(),
            RequesterId = request.RequesterId,
            RecipientId = request.RecipientId,
            Status = "Pending",
            CreatedAt = DateTime.UtcNow
        };

        _context.UserConnections.Add(connection);
        await _context.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("Connection request created: {ConnectionId} from {RequesterId} to {RecipientId}",
            connection.Id, request.RequesterId, request.RecipientId);

        return new CreateConnectionResult(
            request.RequestId,
            true,
            "Connection request sent successfully",
            connection.Id);
    }
}
