
using ViewModels.Base;
using ViewModels.Dtos;

namespace ViewModels.Requests.DataAccess.UserProfile;

public class GetUserForEmailResult : BaseResult
{
    public FullUserProfileDto FullUserProfileDto { get; }

    public GetUserForEmailResult(Guid requestId, FullUserProfileDto fullUserProfileDto)
    {
        FullUserProfileDto = fullUserProfileDto;
        RequestId = requestId;
    }
}