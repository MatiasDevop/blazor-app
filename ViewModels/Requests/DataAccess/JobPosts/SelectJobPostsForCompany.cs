using MediatR;
using ViewModels.Base;
using ViewModels.Dtos;

namespace ViewModels.Requests.DataAccess.JobPosts;

public class SelectJobPostsForCompanyRequest : BaseRequest, IRequest<SelectJobPostsForCompanyResult>
{
    public Guid CompanyClaimId { get; }
    public bool ShowInActives { get; }

    public SelectJobPostsForCompanyRequest(Guid requestId, Guid companyClaimId, bool showInActives)
    {
        CompanyClaimId = companyClaimId;
        ShowInActives = showInActives;
        RequestId = requestId;
    }
}

public class SelectJobPostsForCompanyResult : BaseResult
{
    public List<JobPostDto> JobPosts { get; }

    public SelectJobPostsForCompanyResult(Guid requestId, List<JobPostDto> jobPosts)
    {
        this.JobPosts = jobPosts;
        RequestId = requestId;
    }
}