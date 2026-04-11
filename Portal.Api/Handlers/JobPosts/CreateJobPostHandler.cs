using MediatR;
using Microsoft.EntityFrameworkCore;
using Portal.Api.Data;
using Domain.Entities;
using ViewModels.Requests.Endpoints.JobPosts;
using ViewModels.Dtos;

namespace Portal.Api.Handlers.JobPosts;

public class CreateJobPostHandler : IRequestHandler<CreateJobPostRequest, CreateJobPostResult>
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<CreateJobPostHandler> _logger;

    public CreateJobPostHandler(ApplicationDbContext context, ILogger<CreateJobPostHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<CreateJobPostResult> Handle(CreateJobPostRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var action = request.Action;

            // Validate company exists
            var company = await _context.CompanyProfiles
                .FirstOrDefaultAsync(c => c.Id == action.CompanyId, cancellationToken);

            if (company == null)
            {
                _logger.LogWarning("Company {CompanyId} not found for job post creation", action.CompanyId);
                throw new InvalidOperationException($"Company with ID {action.CompanyId} not found");
            }

            // Create new job post entity
            var jobPost = new JobPost
            {
                Id = Guid.NewGuid(),
                CompanyProfileId = action.CompanyId,
                JobTitle = action.Title,
                Description = action.Description,
                JobLocation = action.Location,
                CompensationDetails = action.CompensationDetails,
                SalaryOffered = action.SalaryOffered,
                UseCpccApplyNow = action.UseCpccApply,
                ApplyUrl = action.ApplyUrl,
                Type = action.JopType,
                DatePosted = action.DateToPost,
                ExpirationDate = action.DateToExpire,
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            // Add requirement groups if provided
            if (action.JobRequirementGroups != null && action.JobRequirementGroups.Any())
            {
                jobPost.RequirementGroups = action.JobRequirementGroups.Select(rg => new JobRequirementGroup
                {
                    Id = Guid.NewGuid(),
                    Name = rg.Label,
                    Label = rg.Label,
                    Order = rg.Order,
                    JobPostId = jobPost.Id
                }).ToList();
            }

            // Add benefits if provided
            if (action.JobBenefits != null && action.JobBenefits.Any())
            {
                jobPost.Benefits = action.JobBenefits.Select(b => new JobBenefit
                {
                    Id = Guid.NewGuid(),
                    Text = b.Text,
                    Name = b.Text,
                    JobPostId = jobPost.Id
                }).ToList();
            }

            // Add questions if provided
            if (action.Questions != null && action.Questions.Any())
            {
                jobPost.Questions = action.Questions.Select(q => new ApplicationQuestion
                {
                    Id = Guid.NewGuid(),
                    Text = q.Text,
                    Question = q.Text,
                    JobPostId = jobPost.Id
                }).ToList();
            }

            _context.JobPosts.Add(jobPost);
            await _context.SaveChangesAsync(cancellationToken);

            _logger.LogInformation("Job post {JobPostId} created for company {CompanyId}", jobPost.Id, action.CompanyId);

            // Map to DTO
            var jobPostDto = new JobPostDto
            {
                Id = jobPost.Id,
                Title = jobPost.JobTitle,
                Description = jobPost.Description,
                Location = jobPost.JobLocation,
                CompanyId = jobPost.CompanyProfileId,
                RecruiterId = action.RecruiterId,
                JopType = jobPost.Type,
                DateToPost = jobPost.DatePosted,
                DateToExpire = jobPost.ExpirationDate,
                CompensationDetails = jobPost.CompensationDetails,
                SalaryOffered = jobPost.SalaryOffered,
                UseCpccApply = jobPost.UseCpccApplyNow,
                ApplyUrl = jobPost.ApplyUrl,
                IsActive = jobPost.IsActive,
                JobRequirementGroups = jobPost.RequirementGroups?.Select(rg => new JobRequirementGroupDto
                {
                    Id = rg.Id,
                    Label = rg.Label,
                    Order = rg.Order,
                    JobPostId = rg.JobPostId
                }).ToList() ?? new List<JobRequirementGroupDto>(),
                JobBenefits = jobPost.Benefits?.Select(b => new JobBenefitDto
                {
                    Id = b.Id,
                    Text = b.Text,
                    JopPostId = b.JobPostId
                }).ToList() ?? new List<JobBenefitDto>(),
                Questions = jobPost.Questions?.Select(q => new ApplicationQuestionDto
                {
                    Id = q.Id,
                    Text = q.Text,
                    JobPostId = q.JobPostId
                }).ToList() ?? new List<ApplicationQuestionDto>()
            };

            return new CreateJobPostResult(request.RequestId, jobPostDto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating job post for request {RequestId}", request.RequestId);
            throw;
        }
    }
}
