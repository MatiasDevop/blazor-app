using MediatR;
using Microsoft.EntityFrameworkCore;
using Portal.Api.Data;
using ViewModels.Requests.Endpoints.JobPosts;

namespace Portal.Api.Handlers.JobPosts;

public class DeleteJobPostHandler : IRequestHandler<DeleteJobPostRequest, DeleteJobPostResult>
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<DeleteJobPostHandler> _logger;

    public DeleteJobPostHandler(ApplicationDbContext context, ILogger<DeleteJobPostHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<DeleteJobPostResult> Handle(DeleteJobPostRequest request, CancellationToken cancellationToken)
    {
        var jobPost = await _context.JobPosts
            .FirstOrDefaultAsync(jp => jp.Id == request.JobPostId, cancellationToken);

        if (jobPost == null)
        {
            _logger.LogWarning("Job post {JobPostId} not found for deletion", request.JobPostId);
            throw new KeyNotFoundException($"Job post with ID {request.JobPostId} not found");
        }

        // Soft delete - mark as inactive instead of hard delete
        jobPost.IsActive = false;
        jobPost.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("Job post {JobPostId} marked as inactive (soft delete)", request.JobPostId);

        return new DeleteJobPostResult(
            request.RequestId,
            true,
            "Job post successfully deleted");
    }
}
