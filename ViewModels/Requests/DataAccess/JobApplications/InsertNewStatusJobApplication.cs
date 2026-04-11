using MediatR;
using ViewModels.Base;
using ViewModels.Dtos;

namespace ViewModels.Requests.DataAccess.JobApplications;

public class InsertNewStatusJobApplicationRequest : BaseRequest, IRequest<InsertNewStatusJobApplicationResult>
{
    public JobApplicationDto InsertStatusJobApplication { get; }

    public InsertNewStatusJobApplicationRequest(Guid requestId, JobApplicationDto insertStatusJobApplication)
    {
        InsertStatusJobApplication = insertStatusJobApplication;
        RequestId = requestId;
    }

}


public class InsertNewStatusJobApplicationResult : BaseResult
{
    public JobApplicationDto InsertStatusJobApplication { get; }

    public InsertNewStatusJobApplicationResult(Guid requestId, JobApplicationDto insertStatusJobApplication)
    {
        InsertStatusJobApplication = insertStatusJobApplication;
        RequestId = requestId;
    }
}