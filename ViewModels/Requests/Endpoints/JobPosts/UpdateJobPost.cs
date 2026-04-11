
using MediatR;
using ViewModels.Base;
using ViewModels.HttpRequests.JobPosts;


namespace ViewModels.Requests.Endpoints.JobPosts;

public class UpdateJobPostRequest : BaseRequest, IRequest<UpdateJobPostResult>
{
    public EditJobPostAction UpdateJob { get; }

    public UpdateJobPostRequest(Guid requestId, EditJobPostAction updateJob)
    {
        UpdateJob = updateJob;
        RequestId = requestId;
    }
}

public class UpdateJobPostResult : BaseResult
{
    public EditJobPostAction UpdateJobPost { get; }

    public UpdateJobPostResult(Guid requestId, EditJobPostAction updateJobPost)
    {
        UpdateJobPost = updateJobPost;
        RequestId = requestId;
    }
}