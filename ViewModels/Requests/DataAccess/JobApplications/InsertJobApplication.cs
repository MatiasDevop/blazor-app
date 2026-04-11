using MediatR;
using ViewModels.Base;
using ViewModels.Dtos;

namespace ViewModels.Requests.DataAccess.JobApplications;

public class InsertJobApplicationRequest : BaseRequest, IRequest<InsertJobApplicationResult>
{
    public JobApplicationDto JobApplication { get; }

    public InsertJobApplicationRequest(Guid requestId, JobApplicationDto jobApplication)
    {
        JobApplication = jobApplication;
        RequestId = requestId;
    }

}

public class InsertJobApplicationResult : BaseResult
{
    public JobApplicationDto JobApplication { get; }

    public InsertJobApplicationResult(Guid requestId, JobApplicationDto jobApplication)
    {
        JobApplication = jobApplication;
        RequestId = requestId;
    }
}