
using MediatR;
using ViewModels.Base;



namespace ViewModels.Requests.DataAccess.CompanyClaims;

public class SelectIsClaimHolderForUserRequest : BaseRequest, IRequest<SelectIsClaimHolderForUserResult>
{
    public string Email { get; }
    public Guid OrgId { get; }

    public SelectIsClaimHolderForUserRequest(Guid requestId, string email, Guid orgId)
    {
        Email = email;
        OrgId = orgId;
        RequestId = requestId;
    }


}



public class SelectIsClaimHolderForUserResult : BaseResult
{
    public bool IsClaimHolder { get; }

    public SelectIsClaimHolderForUserResult(Guid requestId, bool IsClaimHolder)
    {
        this.IsClaimHolder = IsClaimHolder;
        RequestId = requestId;
    }
}