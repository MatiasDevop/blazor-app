using ViewModels.Base;
using ViewModels.Dtos;

namespace ViewModels.Requests.DataAccess.JobPosts;

public class InsertJobPostWithChildrenResult : BaseResult
{
    public JobPostDto Dto { get; }

    public InsertJobPostWithChildrenResult(Guid requestId, JobPostDto dto)
    {
        Dto = dto;
        RequestId = requestId;
    }
}