
using MediatR;
using ViewModels.Base;


namespace ViewModels.Requests.DataAccess.UserProfile;

public class GetOrgConnectionsForUserRequest : BaseRequest, IRequest<GetOrgConnectionsForUserResult>
{
    public string Email { get; }


    public GetOrgConnectionsForUserRequest(Guid requestId, string email)
    {
        Email = email;
        RequestId = requestId;
    }


}