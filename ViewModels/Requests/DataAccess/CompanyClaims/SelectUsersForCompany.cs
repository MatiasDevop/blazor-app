using MediatR;
using ViewModels.Base;
using ViewModels.Dtos;

namespace ViewModels.Requests.DataAccess.CompanyClaims;

public class SelectUsersForCompanyRequest : BaseRequest, IRequest<SelectUsersForCompanyResult>
{
    public Guid CompanyClaimId { get; }
    public SelectUsersForCompanyRequest(Guid requestId, Guid companyClaimId)
    {
        CompanyClaimId = companyClaimId;
        RequestId = requestId;
    }
}

public class SelectUsersForCompanyResult : BaseResult
{
    public IEnumerable<FullOrgUserConnectionDto> Connections { get; }

    public SelectUsersForCompanyResult(Guid requestId, IEnumerable<FullOrgUserConnectionDto> connections)
    {
        Connections = connections;
        RequestId = requestId;
    }
}