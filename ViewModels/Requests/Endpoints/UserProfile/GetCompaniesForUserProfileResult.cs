using ViewModels.Base;
using ViewModels.Dtos;

namespace ViewModels.Requests.Endpoints.UserProfile;

public class GetCompaniesForUserProfileResult : BaseResult
{
    public IEnumerable<CompanyClaimDto> Companies { get; }
    public IEnumerable<SchoolClaimDto> Schools { get; }

    public GetCompaniesForUserProfileResult(Guid requestId, IEnumerable<CompanyClaimDto> companies, IEnumerable<SchoolClaimDto> schools)
    {
        Companies = companies;
        Schools = schools;
        RequestId = requestId;
    }
}