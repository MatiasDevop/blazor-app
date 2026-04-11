
using MediatR;
using ViewModels.Base;
using ViewModels.Dtos;

namespace ViewModels.Requests.Endpoints.JobApplications;

public class GetJobApplicationForUserRequest : BaseRequest, IRequest<GetJobApplicationForUserResult>
{
    public Guid JobPostId { get; set; }
    public Guid ApplicantId { get; set; }

    public GetJobApplicationForUserRequest(Guid requestId, Guid jobPostId, Guid applicantId)
    {
        RequestId = requestId;
        JobPostId = jobPostId;
        ApplicantId = applicantId;
    }

}

public class GetJobApplicationForUserResult : BaseResult
{
    public JobApplicationDto JobApplication { get; }

    public GetJobApplicationForUserResult(Guid requestId, JobApplicationDto jobApplication)
    {
        JobApplication = jobApplication;
        RequestId = requestId;
    }
}