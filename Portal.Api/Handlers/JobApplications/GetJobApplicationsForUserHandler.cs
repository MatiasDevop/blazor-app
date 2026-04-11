using MediatR;
using Microsoft.EntityFrameworkCore;
using Portal.Api.Data;
using ViewModels.Requests.Endpoints.JobApplications;
using ViewModels.Dtos;
using Enums;

namespace Portal.Api.Handlers.JobApplications;

public class GetJobApplicationsForUserHandler : IRequestHandler<GetJobApplicationsForUserRequest, GetJobApplicationsForUserResult>
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<GetJobApplicationsForUserHandler> _logger;

    public GetJobApplicationsForUserHandler(ApplicationDbContext context, ILogger<GetJobApplicationsForUserHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<GetJobApplicationsForUserResult> Handle(GetJobApplicationsForUserRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var applications = await _context.JobApplications
                .Include(ja => ja.JobPost)
                    .ThenInclude(jp => jp.CompanyProfile)
                .Where(ja => ja.UserProfileId == request.ApplicantId)
                .OrderByDescending(ja => ja.DateApplied)
                .Select(ja => new JobApplicationDto
                {
                    Id = ja.Id,
                    JobPostId = ja.JobPostId,
                    ApplicantId = ja.UserProfileId,
                    Status = Enum.Parse<JobApplicationStatus>(ja.Status ?? "Submitted"),
                    DateApplied = ja.DateApplied,
                    DateReviewed = ja.DateReviewed,
                    CoverLetter = ja.CoverLetter
                })
                .ToListAsync(cancellationToken);

            _logger.LogInformation("Retrieved {Count} job applications for user {UserId}", applications.Count, request.ApplicantId);

            return new GetJobApplicationsForUserResult(request.RequestId, applications);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving job applications for user {UserId}, request {RequestId}",
                request.ApplicantId, request.RequestId);
            throw;
        }
    }
}
