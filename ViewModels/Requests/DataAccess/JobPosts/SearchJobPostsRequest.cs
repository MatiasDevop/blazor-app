using MediatR;
using ViewModels.Base;
using ViewModels.Dtos;
using ViewModels.HttpRequests.JobPosts;


namespace ViewModels.Requests.DataAccess.JobPosts;

public class SearchJobPostsRequest : BaseRequest, IRequest<SearchJobPostsResult>
{
    public SearchJobsAction Action { get; }
    public SearchJobPostsRequest(Guid requestId, SearchJobsAction action)
    {
        Action = action;
        RequestId = requestId;
    }
}



public class SearchJobPostsResult : BaseResult
{
    public List<JobPostDto> JobPosts { get; }

    public SearchJobPostsResult(Guid requestId, List<JobPostDto> jobPosts)
    {
        JobPosts = jobPosts;
        RequestId = requestId;
    }
}