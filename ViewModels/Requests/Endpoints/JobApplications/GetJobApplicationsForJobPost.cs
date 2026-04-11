using MediatR;
using ViewModels.Base;
using ViewModels.Dtos;


namespace ViewModels.Requests.Endpoints.JobApplications;

public class GetJobApplicationsForJobPostRequest : BaseRequest, IRequest<GetJobApplicationsForJobPostResult>
{
    public Guid JobPostId { get; }

    public GetJobApplicationsForJobPostRequest(Guid requestId, Guid jobPostId)
    {
        JobPostId = jobPostId;
        RequestId = requestId;
    }


}



public class GetJobApplicationsForJobPostResult : BaseResult
{
    public List<JobApplicationDto> JobApplications { get; }

    public GetJobApplicationsForJobPostResult(Guid requestId, List<JobApplicationDto> jobApplications)
    {
        JobApplications = jobApplications;
        RequestId = requestId;
    }
}