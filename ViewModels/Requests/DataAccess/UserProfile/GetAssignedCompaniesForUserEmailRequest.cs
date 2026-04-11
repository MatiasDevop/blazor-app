using System;
using MediatR;
using ViewModels.Base;

namespace ViewModels.Requests.DataAccess.UserProfile;

public class GetAssignedCompaniesForUserEmailRequest : BaseRequest, IRequest<GetAssignedCompaniesForUserEmailResult>
{
    public string Email { get; }

    public GetAssignedCompaniesForUserEmailRequest(Guid requestId, string email )
    {
        Email = email;
        RequestId = requestId;
    }
}