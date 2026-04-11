using MediatR;
using ViewModels.Base;
using ViewModels.Commands;

namespace ViewModels.Requests.Endpoints.UserProfile;

/// <summary>
/// Request to register a new company user profile and company
/// </summary>
public class RegisterCompanyRequest : BaseRequest, IRequest<RegisterCompanyResult>
{
    public RegisterCompanyCommand Command { get; }

    public RegisterCompanyRequest(Guid requestId, RegisterCompanyCommand command)
    {
        RequestId = requestId;
        Command = command;
    }
}

/// <summary>
/// Result of company registration
/// </summary>
public class RegisterCompanyResult : BaseResult
{
    public Guid UserId { get; }
    public Guid CompanyId { get; }
    public string Email { get; }
    public bool Success { get; }
    public string Message { get; }

    public RegisterCompanyResult(Guid requestId, Guid userId, Guid companyId, string email, bool success = true, string message = "")
    {
        RequestId = requestId;
        UserId = userId;
        CompanyId = companyId;
        Email = email;
        Success = success;
        Message = message;
    }
}
