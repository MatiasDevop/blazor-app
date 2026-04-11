using MediatR;
using ViewModels.Base;
using ViewModels.Dtos;

namespace ViewModels.Requests.Endpoints.JobPosts;

public class GetJobPostRequest : BaseRequest, IRequest<GetJobPostResult>
{
    public Guid JobId { get; }
    public bool ShowInActives { get; }

    public GetJobPostRequest(Guid requestId, Guid jobId, bool showInActives)
    {
        JobId = jobId;
        ShowInActives = showInActives;
        RequestId = requestId;
    }
}



public class GetJobPostResult : BaseResult
{
    public JobPostDto JobPost { get; }

    public GetJobPostResult(Guid requestId, JobPostDto jobPost)
    {
        JobPost = jobPost;
        RequestId = requestId;
    }
}