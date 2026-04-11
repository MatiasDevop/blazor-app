using MediatR;
using ViewModels.Base;

namespace ViewModels.Requests.Endpoints.JobPosts;

public class DeleteJobPostRequest : BaseRequest, IRequest<DeleteJobPostResult>
{
    public Guid JobPostId { get; }

    public DeleteJobPostRequest(Guid requestId, Guid jobPostId)
    {
        JobPostId = jobPostId;
        RequestId = requestId;
    }
}

public class DeleteJobPostResult : BaseResult
{
    public bool Success { get; }
    public string Message { get; }

    public DeleteJobPostResult(Guid requestId, bool success, string message)
    {
        Success = success;
        Message = message;
        RequestId = requestId;
    }
}
