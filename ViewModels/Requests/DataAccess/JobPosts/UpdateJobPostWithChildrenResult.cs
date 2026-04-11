using System;
using ViewModels.Base;
using ViewModels.HttpRequests.JobPosts;

namespace ViewModels.Requests.DataAccess.JobPosts;

public class UpdateJobPostWithChildrenResult : BaseResult
{
    public EditJobPostAction UpdateDto { get; }

    public UpdateJobPostWithChildrenResult(Guid requestId, EditJobPostAction updateDto)
    {
        UpdateDto = updateDto;
        RequestId = requestId;
    }
}