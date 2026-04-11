using MediatR;
using ViewModels.Base;
using ViewModels.Commands;

namespace ViewModels.Requests.Endpoints.UserProfile;

public class UpdateUserProfileRequest : BaseRequest, IRequest<UpdateUserProfileResult>
{
    public Guid UserId { get; }
    public UpdateUserProfileCommand Command { get; }

    public UpdateUserProfileRequest(Guid requestId, Guid userId, UpdateUserProfileCommand command)
    {
        UserId = userId;
        Command = command;
        RequestId = requestId;
    }
}

public class UpdateUserProfileResult : BaseResult
{
    public bool Success { get; }
    public string Message { get; }

    public UpdateUserProfileResult(Guid requestId, bool success, string message)
    {
        Success = success;
        Message = message;
        RequestId = requestId;
    }
}
