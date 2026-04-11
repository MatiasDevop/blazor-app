using MediatR;
using Microsoft.EntityFrameworkCore;
using Portal.Api.Data;
using ViewModels.Requests.Endpoints.JobPosts;
using ViewModels.Dtos;

namespace Portal.Api.Handlers.JobPosts;

public class GetRecommendedJobsHandler : IRequestHandler<GetRecommendedJobsRequest, GetRecommendedJobsResult>
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<GetRecommendedJobsHandler> _logger;

    public GetRecommendedJobsHandler(ApplicationDbContext context, ILogger<GetRecommendedJobsHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<GetRecommendedJobsResult> Handle(GetRecommendedJobsRequest request, CancellationToken cancellationToken)
    {
        // Load user profile with relevant data for matching
        var userProfile = await _context.UserProfiles
            .Include(u => u.EducationHistories)
            .Include(u => u.WorkHistories)
            .Include(u => u.Addresses)
            .FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

        if (userProfile == null)
        {
            _logger.LogWarning("User profile {UserId} not found for job recommendations", request.UserId);
            throw new KeyNotFoundException($"User profile with ID {request.UserId} not found");
        }

        // Get all active job posts with related data
        var allJobs = await _context.JobPosts
            .Include(jp => jp.CompanyProfile)
            .Include(jp => jp.RequirementGroups)
            .Include(jp => jp.Benefits)
            .Include(jp => jp.Questions)
            .Where(jp => jp.IsActive)
            .Where(jp => jp.DatePosted <= DateTime.UtcNow)
            .ToListAsync(cancellationToken);

        // Score and rank jobs based on user profile
        var scoredJobs = allJobs.Select(job => new
        {
            Job = job,
            Score = CalculateMatchScore(job, userProfile)
        })
        .OrderByDescending(x => x.Score)
        .ThenByDescending(x => x.Job.DatePosted)
        .Skip((request.Page - 1) * request.Size)
        .Take(request.Size)
        .ToList();

        // Map to DTOs
        var jobDtos = scoredJobs.Select(x => new JobPostDto
        {
            Id = x.Job.Id,
            Title = x.Job.JobTitle,
            Description = x.Job.Description ?? string.Empty,
            Location = x.Job.JobLocation ?? string.Empty,
            SalaryOffered = x.Job.SalaryOffered ?? string.Empty,
            DateToPost = x.Job.DatePosted,
            DateToExpire = x.Job.ExpirationDate,
            ApplyUrl = x.Job.ApplyUrl ?? string.Empty,
            JopType = x.Job.Type,
            IsActive = x.Job.IsActive,
            CompanyId = x.Job.CompanyProfileId,
            CompensationDetails = x.Job.CompensationDetails ?? string.Empty,
            JobRequirementGroups = x.Job.RequirementGroups.Select(rg => new JobRequirementGroupDto
            {
                Id = rg.Id,
                Label = rg.Label ?? string.Empty,
                Order = rg.Order,
                JobPostId = x.Job.Id,
                Requirements = new List<JobRequirementDto>()
            }).ToList(),
            JobBenefits = x.Job.Benefits.Select(b => new JobBenefitDto
            {
                Id = b.Id,
                Text = b.Text ?? string.Empty,
                JopPostId = x.Job.Id
            }).ToList(),
            Questions = x.Job.Questions.Select(q => new ApplicationQuestionDto
            {
                Id = q.Id,
                Text = q.Text ?? string.Empty,
                JobPostId = x.Job.Id,
                Answers = new List<JobApplicationAnswerDto>()
            }).ToList()
        }).ToList();

        _logger.LogInformation("Retrieved {Count} recommended jobs for user {UserId} (Page {Page}, Size {Size})",
            jobDtos.Count, request.UserId, request.Page, request.Size);

        return new GetRecommendedJobsResult(request.RequestId, jobDtos, allJobs.Count);
    }

    private double CalculateMatchScore(Domain.Entities.JobPost job, Domain.Entities.UserProfile user)
    {
        double score = 0.0;

        // Base score for all active jobs
        score += 10.0;

        // Boost recent postings (within last 30 days)
        if (job.DatePosted >= DateTime.UtcNow.AddDays(-30))
        {
            score += 20.0;
        }

        // Check if user has relevant work experience
        if (user.WorkHistories.Any())
        {
            var recentWork = user.WorkHistories
                .OrderByDescending(wh => wh.StartDate)
                .FirstOrDefault();

            if (recentWork != null)
            {
                // Boost if job title contains keywords from user's work history
                if (!string.IsNullOrWhiteSpace(recentWork.JobTitle) &&
                    job.JobTitle.Contains(recentWork.JobTitle, StringComparison.OrdinalIgnoreCase))
                {
                    score += 30.0;
                }
            }

            // Additional points for having work experience
            score += 15.0;
        }

        // Check education level match
        if (user.EducationHistories.Any())
        {
            score += 10.0;

            var highestEducation = user.EducationHistories
                .OrderByDescending(eh => eh.StartDate)
                .FirstOrDefault();

            if (highestEducation != null)
            {
                // Additional points for recent education
                if (highestEducation.EndDate.HasValue &&
                    highestEducation.EndDate.Value >= DateTime.UtcNow.AddYears(-3))
                {
                    score += 15.0;
                }
            }
        }

        // Location matching (if user has address and job has location)
        if (user.Addresses.Any() && !string.IsNullOrWhiteSpace(job.JobLocation))
        {
            var userAddress = user.Addresses.FirstOrDefault();
            if (userAddress != null && !string.IsNullOrWhiteSpace(userAddress.City))
            {
                // Boost if city matches
                if (job.JobLocation.Contains(userAddress.City, StringComparison.OrdinalIgnoreCase))
                {
                    score += 25.0;
                }
            }
        }

        // Prefer jobs with salary information
        if (!string.IsNullOrWhiteSpace(job.SalaryOffered))
        {
            score += 10.0;
        }

        return score;
    }
}
