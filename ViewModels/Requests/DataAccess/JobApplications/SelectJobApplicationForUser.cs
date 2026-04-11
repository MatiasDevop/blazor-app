using MediatR;
using ViewModels.Base;
using ViewModels.Dtos;

namespace ViewModels.Requests.DataAccess.JobApplications;

public class SelectJobApplicationForUserRequest : BaseRequest, IRequest<SelectJobApplicationForUserResult>
{
    public Guid JobPostId { get; set; }
    public Guid ApplicantId { get; set; }

    public SelectJobApplicationForUserRequest(Guid requestId, Guid jobPostId, Guid applicantId)
    {
        RequestId = requestId;
        JobPostId = jobPostId;
        ApplicantId = applicantId;
    }

}

public class SelectJobApplicationForUserResult : BaseResult
{
    public JobApplicationDto JobApplication { get; }

    public SelectJobApplicationForUserResult(Guid requestId, JobApplicationDto jobApplication)
    {
        JobApplication = jobApplication;
        RequestId = requestId;
    }
}