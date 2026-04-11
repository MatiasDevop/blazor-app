using MediatR;
using ViewModels.Base;
using ViewModels.Dtos;


namespace ViewModels.Requests.DataAccess.JobApplications;

public class SelectJobApplicationsForJobPostRequest : BaseRequest, IRequest<SelectJobApplicationsForJobPostResult>
{
    public Guid JobPostId { get; }

    public SelectJobApplicationsForJobPostRequest(Guid requestId, Guid jobPostId)
    {
        JobPostId = jobPostId;
        RequestId = requestId;
    }


}



public class SelectJobApplicationsForJobPostResult : BaseResult
{
    public List<JobApplicationDto> JobApplications { get; }

    public SelectJobApplicationsForJobPostResult(Guid requestId, List<JobApplicationDto> jobApplications)
    {
        JobApplications = jobApplications;
        RequestId = requestId;
    }
}