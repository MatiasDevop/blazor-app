using MediatR;
using Microsoft.EntityFrameworkCore;
using Portal.Api.Data;
using ViewModels.Requests.Endpoints.Connections;
using ViewModels.Dtos;
using Enums;

namespace Portal.Api.Handlers.Connections;

public class GetUserConnectionsHandler : IRequestHandler<GetUserConnectionsRequest, GetUserConnectionsResult>
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<GetUserConnectionsHandler> _logger;

    public GetUserConnectionsHandler(ApplicationDbContext context, ILogger<GetUserConnectionsHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<GetUserConnectionsResult> Handle(GetUserConnectionsRequest request, CancellationToken cancellationToken)
    {
        var query = _context.UserConnections
            .Include(c => c.Requester)
            .Include(c => c.Recipient)
            .Where(c => c.RequesterId == request.UserId || c.RecipientId == request.UserId);

        // Filter by status if provided
        if (!string.IsNullOrWhiteSpace(request.Status))
        {
            query = query.Where(c => c.Status == request.Status);
        }

        var connections = await query.ToListAsync(cancellationToken);

        var connectionDtos = connections.Select(c => new UserConnectionDto
        {
            Id = c.Id,
            // Return the other user's ID (not the requesting user's ID)
            UserId = c.RequesterId == request.UserId ? c.RecipientId : c.RequesterId,
            Type = UserConnectionType.BasicConnection,
            DateApproved = c.DateApproved,
            DateRequested = c.CreatedAt,
            ApproverMessage = c.Status ?? string.Empty
        }).ToList();

        _logger.LogInformation("Retrieved {Count} connections for user {UserId}",
            connectionDtos.Count, request.UserId);

        return new GetUserConnectionsResult(request.RequestId, connectionDtos);
    }
}
