using MediatR;
using ViewModels.Base;
using ViewModels.Dtos;


namespace ViewModels.Requests.Endpoints.UserProfile;

public class GetPermissionsForCurrentOrgRequest : BaseRequest, IRequest<GetPermissionsForCurrentOrgResult>
{
    public string Email { get; }
    public Guid OrgId { get; }

    public GetPermissionsForCurrentOrgRequest(Guid requestId, string email, Guid orgId)
    {
        Email = email;
        OrgId = orgId;
        RequestId = requestId;
    }


}



public class GetPermissionsForCurrentOrgResult : BaseResult
{
    public IEnumerable<OrgUserConnectionDto> Permissions { get; }
    public bool IsClaimHolder { get; }

    public GetPermissionsForCurrentOrgResult(Guid requestId, IEnumerable<OrgUserConnectionDto> permissions, bool isClaimHolder)
    {
        Permissions = permissions;
        IsClaimHolder = isClaimHolder;
        RequestId = requestId;
    }
}