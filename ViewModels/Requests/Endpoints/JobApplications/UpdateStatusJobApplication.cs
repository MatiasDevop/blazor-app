
using MediatR;
using ViewModels.Base;
using ViewModels.Dtos;


namespace ViewModels.Requests.Endpoints.JobApplications;

public class UpdateStatusJobApplicationRequest : BaseRequest, IRequest<UpdateStatusJobApplicationResult>
{
    public JobApplicationDto UpdateStatusJobApplication { get; }

    public UpdateStatusJobApplicationRequest(Guid requestId, JobApplicationDto updateStatusJobApplication)
    {
        UpdateStatusJobApplication = updateStatusJobApplication;
        RequestId = requestId;
    }
}


public class UpdateStatusJobApplicationResult : BaseResult
{
    public JobApplicationDto UpdateStatusJobApplication { get; }

    public UpdateStatusJobApplicationResult(Guid requestId, JobApplicationDto updateStatusJobApplication)
    {
        UpdateStatusJobApplication = updateStatusJobApplication;
        RequestId = requestId;
    }
}