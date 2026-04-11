using MediatR;
using ViewModels.Base;
using ViewModels.Dtos;

namespace ViewModels.Requests.DataAccess.JobPosts;

public class SelectJobPostRequest : BaseRequest, IRequest<SelectJobPostResult>
{
    public Guid JobId { get; }
    public bool ShowInActives { get; }

    public SelectJobPostRequest(Guid requestId, Guid jobId, bool showInActives)
    {
        JobId = jobId;
        ShowInActives = showInActives;
        RequestId = requestId;
    }
}



public class SelectJobPostResult : BaseResult
{
    public JobPostDto JobPost { get; }

    public SelectJobPostResult(Guid requestId, JobPostDto jobPost)
    {
        this.JobPost = jobPost;
        RequestId = requestId;
    }
}