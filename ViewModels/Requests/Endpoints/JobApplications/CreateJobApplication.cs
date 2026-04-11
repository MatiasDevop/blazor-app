using System;
using MediatR;
using ViewModels.Dtos;
using ViewModels.Base;

namespace ViewModels.Requests.Endpoints.JobApplications;

public class CreateJobApplicationRequest : BaseRequest, IRequest<CreateJobApplicationResult>
{
    public JobApplicationDto JobApplication { get; }

    public CreateJobApplicationRequest(Guid requestId, JobApplicationDto jobApplication)
    {
        JobApplication = jobApplication;
        RequestId = requestId;
    }
}

public class CreateJobApplicationResult : BaseResult
{
    public JobApplicationDto JobApplication { get; }

    public CreateJobApplicationResult(Guid requestId, JobApplicationDto jobApplication)
    {
        JobApplication = jobApplication;
        RequestId = requestId;
    }
}