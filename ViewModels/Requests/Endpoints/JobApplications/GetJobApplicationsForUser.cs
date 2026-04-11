
using MediatR;
using ViewModels.Base;
using ViewModels.Dtos;

namespace ViewModels.Requests.Endpoints.JobApplications;

public class GetJobApplicationsForUserRequest : BaseRequest, IRequest<GetJobApplicationsForUserResult>
{
    public Guid ApplicantId { get; set; }

    public GetJobApplicationsForUserRequest(Guid requestId, Guid applicantId)
    {
        RequestId = requestId;
        ApplicantId = applicantId;
    }
}

public class GetJobApplicationsForUserResult : BaseResult
{
    public List<JobApplicationDto> JobApplications { get; }

    public GetJobApplicationsForUserResult(Guid requestId, List<JobApplicationDto> jobApplications)
    {
        JobApplications = jobApplications;
        RequestId = requestId;
    }
}