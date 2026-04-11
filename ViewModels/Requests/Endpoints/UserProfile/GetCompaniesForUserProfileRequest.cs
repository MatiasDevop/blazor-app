using System;
using MediatR;
using ViewModels.Base;

namespace ViewModels.Requests.Endpoints.UserProfile;

public class GetCompaniesForUserProfileRequest:BaseRequest,  IRequest<GetCompaniesForUserProfileResult>
{
    public string Email { get; }

    public GetCompaniesForUserProfileRequest(Guid requestId, string email)
    {
        Email = email;
        RequestId = requestId;
    }
}