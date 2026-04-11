
using MediatR;
using ViewModels.Base;
using ViewModels.Dtos;

namespace ViewModels.Requests.Endpoints.JobPosts;

public class GetJobPostsForCompanyRequest : BaseRequest, IRequest<GetJobPostsForCompanyResult>
{
    public Guid CompanyClaimId { get; }
    public bool ShowInActives { get; }

    public GetJobPostsForCompanyRequest(Guid requestId, Guid companyClaimId, bool showInActives)
    {
        CompanyClaimId = companyClaimId;
        ShowInActives = showInActives;
        RequestId = requestId;
    }
}



public class GetJobPostsForCompanyResult : BaseResult
{
    public IEnumerable<JobPostDto> JobPosts { get; }

    public GetJobPostsForCompanyResult(Guid requestId, IEnumerable<JobPostDto> jobPosts)
    {
        JobPosts = jobPosts;
        RequestId = requestId;
    }
}