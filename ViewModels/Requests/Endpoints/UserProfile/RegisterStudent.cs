using MediatR;
using ViewModels.Base;
using ViewModels.Commands;

namespace ViewModels.Requests.Endpoints.UserProfile;

/// <summary>
/// Request to register a new student user profile
/// </summary>
public class RegisterStudentRequest : BaseRequest, IRequest<RegisterStudentResult>
{
    public RegisterStudentCommand Command { get; }

    public RegisterStudentRequest(Guid requestId, RegisterStudentCommand command)
    {
        RequestId = requestId;
        Command = command;
    }
}

/// <summary>
/// Result of student registration
/// </summary>
public class RegisterStudentResult : BaseResult
{
    public Guid UserId { get; }
    public string Email { get; }
    public bool Success { get; }
    public string Message { get; }

    public RegisterStudentResult(Guid requestId, Guid userId, string email, bool success = true, string message = "")
    {
        RequestId = requestId;
        UserId = userId;
        Email = email;
        Success = success;
        Message = message;
    }
}
