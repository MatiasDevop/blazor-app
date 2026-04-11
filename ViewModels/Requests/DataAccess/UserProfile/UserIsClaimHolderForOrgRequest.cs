using System;
using MediatR;
using ViewModels.Base;


namespace ViewModels.Requests.DataAccess.UserProfile;

public class UserIsClaimHolderForOrgRequest : BaseRequest, IRequest<UserIsClaimHolderForOrgResult>
{
    public string Email { get; }
    public Guid OrgId { get; }

    public UserIsClaimHolderForOrgRequest(Guid requestId, string email, Guid orgId)
    {
        Email = email;
        OrgId = orgId;
        RequestId = requestId;
    }
}