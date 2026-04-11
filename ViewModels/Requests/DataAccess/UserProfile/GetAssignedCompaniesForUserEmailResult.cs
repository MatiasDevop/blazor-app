
using ViewModels.Base;
using ViewModels.Dtos;

namespace ViewModels.Requests.DataAccess.UserProfile;

public class GetAssignedCompaniesForUserEmailResult : BaseResult
{
    public IEnumerable<CompanyClaimDto> Companies { get; }

    public GetAssignedCompaniesForUserEmailResult(Guid requestId, List<CompanyClaimDto> companies)
    {
        Companies = companies;
        RequestId = requestId;
    }
}