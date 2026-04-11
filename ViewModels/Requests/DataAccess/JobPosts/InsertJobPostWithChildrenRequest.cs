using MediatR;
using ViewModels.Base;
using ViewModels.HttpRequests.JobPosts;


namespace ViewModels.Requests.DataAccess.JobPosts;

public class InsertJobPostWithChildrenRequest : BaseRequest, IRequest<InsertJobPostWithChildrenResult>
{
    public CreateJobPostAction Action { get; }

    public InsertJobPostWithChildrenRequest(Guid requestId, CreateJobPostAction action)
    {
        Action = action;
        RequestId = requestId;
    }
}