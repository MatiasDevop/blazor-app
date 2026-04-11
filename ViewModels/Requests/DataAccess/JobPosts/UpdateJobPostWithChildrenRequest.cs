using MediatR;
using ViewModels.Base;
using ViewModels.HttpRequests.JobPosts;


namespace ViewModels.Requests.DataAccess.JobPosts;

public class UpdateJobPostWithChildrenRequest : BaseRequest, IRequest<UpdateJobPostWithChildrenResult>
{
    public EditJobPostAction UpdateJob { get; }

    public UpdateJobPostWithChildrenRequest(Guid requestId, EditJobPostAction updateJob)
    {
        UpdateJob = updateJob;
        RequestId = requestId;
    }

}