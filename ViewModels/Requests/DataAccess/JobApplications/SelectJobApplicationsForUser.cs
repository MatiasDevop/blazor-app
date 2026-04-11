using MediatR;
using ViewModels.Base;
using ViewModels.Dtos;

namespace ViewModels.Requests.DataAccess.JobApplications;

public class SelectJobApplicationsForUserRequest : BaseRequest, IRequest<SelectJobApplicationsForUserResult>
{
    public Guid ApplicantId { get; set; }

    public SelectJobApplicationsForUserRequest(Guid requestId, Guid applicantId)
    {
        RequestId = requestId;
        ApplicantId = applicantId;
    }

}

public class SelectJobApplicationsForUserResult : BaseResult
{
    public List<JobApplicationDto> JobApplications { get; }

    public SelectJobApplicationsForUserResult(Guid requestId, List<JobApplicationDto> jobApplications)
    {
        JobApplications = jobApplications;
        RequestId = requestId;
    }
}