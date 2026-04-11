using MediatR;
using Microsoft.EntityFrameworkCore;
using Portal.Api.Data;
using ViewModels.Requests.Endpoints.JobPosts;
using ViewModels.Dtos;

namespace Portal.Api.Handlers.JobPosts;

public class GetJobPostHandler : IRequestHandler<GetJobPostRequest, GetJobPostResult>
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<GetJobPostHandler> _logger;

    public GetJobPostHandler(ApplicationDbContext context, ILogger<GetJobPostHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<GetJobPostResult> Handle(GetJobPostRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var query = _context.JobPosts
                .Include(jp => jp.RequirementGroups)
                .Include(jp => jp.Benefits)
                .Include(jp => jp.Questions)
                .Include(jp => jp.CompanyProfile)
                .AsQueryable();

            if (!request.ShowInActives)
            {
                query = query.Where(jp => jp.IsActive);
            }

            var jobPost = await query
                .FirstOrDefaultAsync(jp => jp.Id == request.JobId, cancellationToken);

            if (jobPost == null)
            {
                _logger.LogWarning("Job post {JobId} not found", request.JobId);
                throw new KeyNotFoundException($"Job post with ID {request.JobId} not found");
            }

            // Map to DTO
            var jobPostDto = new JobPostDto
            {
                Id = jobPost.Id,
                Title = jobPost.JobTitle,
                Description = jobPost.Description,
                Location = jobPost.JobLocation,
                CompanyId = jobPost.CompanyProfileId,
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

            return new GetJobPostResult(request.RequestId, jobPostDto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving job post {JobId} for request {RequestId}", request.JobId, request.RequestId);
            throw;
        }
    }
}
