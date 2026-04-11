using MediatR;
using ViewModels.Base;
using ViewModels.Dtos;

namespace ViewModels.Requests.Endpoints.Connections;

public class GetUserConnectionsRequest : BaseRequest, IRequest<GetUserConnectionsResult>
{
    public Guid UserId { get; }
    public string? Status { get; }

    public GetUserConnectionsRequest(Guid requestId, Guid userId, string? status = null)
    {
        RequestId = requestId;
        UserId = userId;
        Status = status;
    }
}

public class GetUserConnectionsResult : BaseResult
{
    public List<UserConnectionDto> Connections { get; }

    public GetUserConnectionsResult(Guid requestId, List<UserConnectionDto> connections)
    {
        RequestId = requestId;
        Connections = connections;
    }
}
