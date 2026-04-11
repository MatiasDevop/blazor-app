using MediatR;
using Microsoft.EntityFrameworkCore;
using Portal.Api.Data;
using Domain.Entities;
using ViewModels.Requests.Endpoints.JobApplications;
using ViewModels.Dtos;
using Enums;

namespace Portal.Api.Handlers.JobApplications;

public class CreateJobApplicationHandler : IRequestHandler<CreateJobApplicationRequest, CreateJobApplicationResult>
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<CreateJobApplicationHandler> _logger;

    public CreateJobApplicationHandler(ApplicationDbContext context, ILogger<CreateJobApplicationHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<CreateJobApplicationResult> Handle(CreateJobApplicationRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var dto = request.JobApplication;

            // Validate job post exists and is active
            var jobPost = await _context.JobPosts
                .FirstOrDefaultAsync(jp => jp.Id == dto.JobPostId, cancellationToken);

            if (jobPost == null)
            {
                _logger.LogWarning("Job post {JobPostId} not found for application", dto.JobPostId);
                throw new KeyNotFoundException($"Job post with ID {dto.JobPostId} not found");
            }

            if (!jobPost.IsActive)
            {
                _logger.LogWarning("Job post {JobPostId} is not active", dto.JobPostId);
                throw new InvalidOperationException($"Cannot apply to inactive job post {dto.JobPostId}");
            }

            // Check if user already applied
            var existingApplication = await _context.JobApplications
                .FirstOrDefaultAsync(ja => ja.JobPostId == dto.JobPostId && ja.UserProfileId == dto.ApplicantId, cancellationToken);

            if (existingApplication != null)
            {
                _logger.LogWarning("User {UserId} already applied to job post {JobPostId}", dto.ApplicantId, dto.JobPostId);
                throw new InvalidOperationException($"User has already applied to this job post");
            }

            // Create new job application
            var jobApplication = new JobApplication
            {
                Id = Guid.NewGuid(),
                JobPostId = dto.JobPostId,
                UserProfileId = dto.ApplicantId,
                Status = Enum.GetName(JobApplicationStatus.NotTracked),
                AppliedAt = DateTime.UtcNow,
                DateApplied = DateTime.UtcNow,
                CoverLetter = dto.CoverLetter
            };

            _context.JobApplications.Add(jobApplication);
            await _context.SaveChangesAsync(cancellationToken);

            _logger.LogInformation("Job application {ApplicationId} created for user {UserId} on job post {JobPostId}",
                jobApplication.Id, dto.ApplicantId, dto.JobPostId);

            // Map to DTO
            var resultDto = new JobApplicationDto
            {
                Id = jobApplication.Id,
                JobPostId = jobApplication.JobPostId,
                ApplicantId = jobApplication.UserProfileId,
                Status = JobApplicationStatus.NotTracked,
                DateApplied = jobApplication.DateApplied,
                CoverLetter = jobApplication.CoverLetter
            };

            return new CreateJobApplicationResult(request.RequestId, resultDto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating job application for request {RequestId}", request.RequestId);
            throw;
        }
    }
}
