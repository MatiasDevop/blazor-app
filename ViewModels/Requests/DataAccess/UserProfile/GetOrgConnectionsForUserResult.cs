
using ViewModels.Base;
using ViewModels.Dtos;

namespace ViewModels.Requests.DataAccess.UserProfile;

public class GetOrgConnectionsForUserResult : BaseResult
{
    public IEnumerable<OrgUserConnectionDto> Connections { get; }

    public GetOrgConnectionsForUserResult(Guid requestId, IEnumerable<OrgUserConnectionDto> connections)
    {
        Connections = connections;
        RequestId = requestId;
    }
}