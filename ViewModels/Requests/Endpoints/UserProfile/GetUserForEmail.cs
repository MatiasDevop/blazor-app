using MediatR;
using ViewModels.Base;
using ViewModels.Dtos;

namespace ViewModels.Requests.Endpoints.UserProfile;

public class GetUserForEmailRequest : BaseRequest, IRequest<GetUserForEmailResult>
{
    public string Email { get; }

    public GetUserForEmailRequest(Guid requestId, string email)
    {
        Email = email;
        RequestId = requestId;
    }
}

public class GetUserForEmailResult : BaseResult
{
    public UserProfileDto? UserProfile { get; }
    public bool Found { get; }

    public GetUserForEmailResult(Guid requestId, UserProfileDto? userProfile, bool found)
    {
        UserProfile = userProfile;
        Found = found;
        RequestId = requestId;
    }
}
