using System;
using System.Collections.Generic;
using MediatR;
using ViewModels.Dtos;
using ViewModels.Base;


namespace ViewModels.Requests.Endpoints.Companies;

public class GetOrgUsersForOrgIdRequest : BaseRequest, IRequest<GetOrgUsersForOrgIdResult>
{
    public Guid CompanyId { get; }

    public GetOrgUsersForOrgIdRequest(Guid requestId, Guid companyId)
    {
        CompanyId = companyId;
        RequestId = requestId;
    }


}



public class GetOrgUsersForOrgIdResult : BaseResult
{
    public IEnumerable<FullOrgUserConnectionDto> OrgUsers { get; }

    public GetOrgUsersForOrgIdResult(Guid requestId, IEnumerable<FullOrgUserConnectionDto> orgUsers)
    {
        OrgUsers = orgUsers;
        RequestId = requestId;
    }
}