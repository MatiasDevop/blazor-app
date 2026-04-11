using MediatR;
using ViewModels.Base;
using ViewModels.Commands;

namespace ViewModels.Requests.Endpoints.UserProfile;

/// <summary>
/// Request to register a new career center user profile and school
/// </summary>
public class RegisterCareerCenterRequest : BaseRequest, IRequest<RegisterCareerCenterResult>
{
    public RegisterCareerCenterCommand Command { get; }

    public RegisterCareerCenterRequest(Guid requestId, RegisterCareerCenterCommand command)
    {
        RequestId = requestId;
        Command = command;
    }
}

/// <summary>
/// Result of career center registration
/// </summary>
public class RegisterCareerCenterResult : BaseResult
{
    public Guid UserId { get; }
    public Guid SchoolId { get; }
    public string Email { get; }
    public bool Success { get; }
    public string Message { get; }

    public RegisterCareerCenterResult(Guid requestId, Guid userId, Guid schoolId, string email, bool success = true, string message = "")
    {
        RequestId = requestId;
        UserId = userId;
        SchoolId = schoolId;
        Email = email;
        Success = success;
        Message = message;
    }
}
