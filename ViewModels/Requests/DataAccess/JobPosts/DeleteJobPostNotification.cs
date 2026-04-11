
using MediatR;
using ViewModels.Base;

namespace ViewModels.Requests.DataAccess.JobPosts;

public class DeleteJobPostNotification : BaseRequest, INotification
{
    public Guid JobPostId { get; set; }

    public DeleteJobPostNotification(Guid requestId, Guid jobPostId)
    {
        RequestId = requestId;
        JobPostId = jobPostId;
    }
}