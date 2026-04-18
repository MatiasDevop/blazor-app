using MediatR;
using ViewModels.Base;
using ViewModels.Dtos;

namespace ViewModels.Requests.Endpoints.UserProfile;

public class GetUserProfileRequest : BaseRequest, IRequest<GetUserProfileResult>
{
    public Guid UserId { get; }

    public GetUserProfileRequest(Guid requestId, Guid userId)
    {
        UserId = userId;
        RequestId = requestId;
    }
}

public class GetUserProfileResult : BaseResult
{
    public PartialUserProfileDto UserProfile { get; }

    public GetUserProfileResult(Guid requestId, PartialUserProfileDto userProfile)
    {
        UserProfile = userProfile;
        RequestId = requestId;
    }
}
