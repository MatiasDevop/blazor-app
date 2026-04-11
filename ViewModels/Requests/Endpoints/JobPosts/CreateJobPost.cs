
using MediatR;
using ViewModels.Base;
using ViewModels.Dtos;
using ViewModels.HttpRequests.JobPosts;


namespace ViewModels.Requests.Endpoints.JobPosts;

public class CreateJobPostRequest : BaseRequest, IRequest<CreateJobPostResult>
{
    public CreateJobPostAction Action { get; }

    public CreateJobPostRequest(Guid requestId, CreateJobPostAction action)
    {
        Action = action;
        RequestId = requestId;
    }

}



public class CreateJobPostResult : BaseResult
{
    public JobPostDto JobPost { get; }

    public CreateJobPostResult(Guid requestId, JobPostDto jobPost)
    {
        JobPost = jobPost;
        RequestId = requestId;
    }
}