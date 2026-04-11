using MediatR;
using ViewModels.Base;
using ViewModels.Dtos;
using ViewModels.HttpRequests.JobPosts;


namespace ViewModels.Requests.Endpoints.JobPosts;

public class JobSearchRequest : BaseRequest, IRequest<JobSearchResult>
{
    public SearchJobsAction Action { get; }

    public JobSearchRequest(Guid requestId, SearchJobsAction action)
    {
        Action = action;
        RequestId = requestId;
    }
}



public class JobSearchResult : BaseResult
{
    public IEnumerable<JobPostDto> Results { get; }

    public JobSearchResult(Guid requestId, IEnumerable<JobPostDto> results)
    {
        Results = results;
        RequestId = requestId;
    }
}