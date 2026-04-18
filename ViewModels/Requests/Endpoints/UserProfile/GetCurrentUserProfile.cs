using MediatR;
using ViewModels.Base;
using ViewModels.Dtos;

namespace ViewModels.Requests.Endpoints.UserProfile;

public class GetCurrentUserProfileRequest : BaseRequest, IRequest<GetCurrentUserProfileResult>
{
    public string Email { get; }

    public GetCurrentUserProfileRequest(Guid requestId, string email)
    {
        RequestId = requestId;
        Email = email;
    }
}

public class GetCurrentUserProfileResult : BaseResult
{
    public FullUserProfileDto? Profile { get; }
    public bool Found { get; }

    public GetCurrentUserProfileResult(Guid requestId, FullUserProfileDto? profile, bool found)
    {
        RequestId = requestId;
        Profile = profile;
        Found = found;
    }
}
