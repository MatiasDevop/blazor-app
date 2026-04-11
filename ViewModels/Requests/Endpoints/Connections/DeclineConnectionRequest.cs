using MediatR;
using ViewModels.Base;

namespace ViewModels.Requests.Endpoints.Connections;

public class DeclineConnectionRequest : BaseRequest, IRequest<DeclineConnectionResult>
{
    public Guid ConnectionId { get; }
    public Guid UserId { get; }

    public DeclineConnectionRequest(Guid requestId, Guid connectionId, Guid userId)
    {
        RequestId = requestId;
        ConnectionId = connectionId;
        UserId = userId;
    }
}

public class DeclineConnectionResult : BaseResult
{
    public bool Success { get; }
    public string Message { get; }

    public DeclineConnectionResult(Guid requestId, bool success, string message)
    {
        RequestId = requestId;
        Success = success;
        Message = message;
    }
}
