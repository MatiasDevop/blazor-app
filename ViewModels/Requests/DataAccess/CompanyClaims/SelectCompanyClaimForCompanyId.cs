using MediatR;
using ViewModels.Dtos;
using ViewModels.Base;


namespace ViewModels.Requests.DataAccess.CompanyClaims;

public class SelectCompanyClaimForCompanyIdRequest : BaseRequest, IRequest<SelectCompanyClaimForCompanyIdResult>
{
    public Guid CompanyId { get; }

    public SelectCompanyClaimForCompanyIdRequest(Guid requestId, Guid companyId)
    {
        CompanyId = companyId;
        RequestId = requestId;
    }


}



public class SelectCompanyClaimForCompanyIdResult : BaseResult
{
    public CompanyClaimDto Dto { get; }

    public SelectCompanyClaimForCompanyIdResult(Guid requestId, CompanyClaimDto dto)
    {
        Dto = dto;
        RequestId = requestId;
    }
}