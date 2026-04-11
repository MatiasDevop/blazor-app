
using ViewModels.Base;
using ViewModels.Dtos;

namespace ViewModels.Requests.DataAccess.UserProfile;

public class GetAssignedSchoolsForUserEmailResult : BaseResult
{
    public IEnumerable<SchoolClaimDto> Schools { get; }

    public GetAssignedSchoolsForUserEmailResult(Guid requestId, IEnumerable<SchoolClaimDto> schools)
    {
        Schools = schools;
        RequestId = requestId;
    }
}