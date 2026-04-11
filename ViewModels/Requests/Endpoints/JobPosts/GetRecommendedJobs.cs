using MediatR;
using ViewModels.Base;
using ViewModels.Dtos;

namespace ViewModels.Requests.Endpoints.JobPosts;

public class GetRecommendedJobsRequest : BaseRequest, IRequest<GetRecommendedJobsResult>
{
    public Guid UserId { get; }
    public int Page { get; }
    public int Size { get; }

    public GetRecommendedJobsRequest(Guid requestId, Guid userId, int page = 1, int size = 10)
    {
        RequestId = requestId;
        UserId = userId;
        Page = page;
        Size = size;
    }
}

public class GetRecommendedJobsResult : BaseResult
{
    public List<JobPostDto> Jobs { get; }
    public int TotalCount { get; }

    public GetRecommendedJobsResult(Guid requestId, List<JobPostDto> jobs, int totalCount)
    {
        RequestId = requestId;
        Jobs = jobs;
        TotalCount = totalCount;
    }
}
