using System;
using MediatR;
using ViewModels.Base;

namespace ViewModels.Requests.DataAccess.UserProfile;

public class GetAssignedSchoolsForUserEmailRequest : BaseRequest, IRequest<GetAssignedSchoolsForUserEmailResult>
{
    public string Email { get; }

    public GetAssignedSchoolsForUserEmailRequest(Guid requestId, string email )
    {
        Email = email;
        RequestId = requestId;
    }
}