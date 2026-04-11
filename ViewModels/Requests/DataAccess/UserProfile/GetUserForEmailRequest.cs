using MediatR;
using ViewModels.Base;


namespace ViewModels.Requests.DataAccess.UserProfile;

public class GetUserForEmailRequest : BaseRequest, IRequest<GetUserForEmailResult>
{
    public string Email { get; }

    public GetUserForEmailRequest(Guid requestId, string email)
    {
        Email = email;
        RequestId = requestId;
    }


}