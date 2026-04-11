using MediatR;
using ViewModels.Base;

namespace ViewModels.Requests.Endpoints.Connections;

public class CreateConnectionRequest : BaseRequest, IRequest<CreateConnectionResult>
{
    public Guid RequesterId { get; }
    public Guid RecipientId { get; }

    public CreateConnectionRequest(Guid requestId, Guid requesterId, Guid recipientId)
    {
        RequestId = requestId;
        RequesterId = requesterId;
        RecipientId = recipientId;
    }
}

public class CreateConnectionResult : BaseResult
{
    public bool Success { get; }
    public string Message { get; }
    public Guid? ConnectionId { get; }

    public CreateConnectionResult(Guid requestId, bool success, string message, Guid? connectionId = null)
    {
        RequestId = requestId;
        Success = success;
        Message = message;
        ConnectionId = connectionId;
    }
}
