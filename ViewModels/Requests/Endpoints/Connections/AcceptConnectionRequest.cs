using MediatR;
using ViewModels.Base;

namespace ViewModels.Requests.Endpoints.Connections;

public class AcceptConnectionRequest : BaseRequest, IRequest<AcceptConnectionResult>
{
    public Guid ConnectionId { get; }
    public Guid ApproverId { get; }

    public AcceptConnectionRequest(Guid requestId, Guid connectionId, Guid approverId)
    {
        RequestId = requestId;
        ConnectionId = connectionId;
        ApproverId = approverId;
    }
}

public class AcceptConnectionResult : BaseResult
{
    public bool Success { get; }
    public string Message { get; }

    public AcceptConnectionResult(Guid requestId, bool success, string message)
    {
        RequestId = requestId;
        Success = success;
        Message = message;
    }
}
