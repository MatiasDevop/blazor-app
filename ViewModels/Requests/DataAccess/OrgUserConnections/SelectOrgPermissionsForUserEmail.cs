using MediatR;
using ViewModels.Base;
using ViewModels.Dtos;


namespace ViewModels.Requests.DataAccess.OrgUserConnections;

public class SelectOrgPermissionsForUserEmailRequest : BaseRequest, IRequest<SelectOrgPermissionsForUserEmailResult>
{
    public string Email { get; }
    public Guid OrgId { get; }

    public SelectOrgPermissionsForUserEmailRequest(Guid requestId, string email, Guid orgId)
    {
        Email = email;
        OrgId = orgId;
        RequestId = requestId;
    }


}



public class SelectOrgPermissionsForUserEmailResult : BaseResult
{
    public IEnumerable<OrgUserConnectionDto> Connections { get; }

    public SelectOrgPermissionsForUserEmailResult(Guid requestId, IEnumerable<OrgUserConnectionDto> connections)
    {
        Connections = connections;
        RequestId = requestId;
    }
}