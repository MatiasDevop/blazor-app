using MediatR;
using Microsoft.EntityFrameworkCore;
using Portal.Api.Data;
using ViewModels.Requests.DataAccess.JobPosts;
using ViewModels.Dtos;
using Enums;

namespace Portal.Api.Handlers.JobPosts;

public class SearchJobPostsHandler : IRequestHandler<SearchJobPostsRequest, SearchJobPostsResult>
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<SearchJobPostsHandler> _logger;

    public SearchJobPostsHandler(ApplicationDbContext context, ILogger<SearchJobPostsHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<SearchJobPostsResult> Handle(SearchJobPostsRequest request, CancellationToken cancellationToken)
    {
        var action = request.Action;

        var query = _context.JobPosts
            .Include(jp => jp.CompanyProfile)
            .Include(jp => jp.RequirementGroups)
            .Include(jp => jp.Benefits)
            .Include(jp => jp.Questions)
            .Where(jp => jp.IsActive)
            .AsQueryable();

        // Apply filters
        if (!string.IsNullOrWhiteSpace(action.LocationSearch))
        {
            query = query.Where(jp => jp.JobLocation.Contains(action.LocationSearch));
        }

        if (action.JobType.HasValue)
        {
            query = query.Where(jp => jp.Type == action.JobType.Value);
        }

        // Apply sorting
        query = action.SortBy switch
        {
            JobPostSortingEnum.DatePosted => query.OrderByDescending(jp => jp.DatePosted),
            JobPostSortingEnum.JobTitle => query.OrderBy(jp => jp.JobTitle),
            JobPostSortingEnum.CompanyName => query.OrderBy(jp => jp.CompanyProfile != null ? jp.CompanyProfile.Name : ""),
            JobPostSortingEnum.RelevanceBasedOnProfile => query.OrderByDescending(jp => jp.DatePosted),
            _ => query.OrderByDescending(jp => jp.DatePosted)
        };

        // Apply pagination
        var pageSize = action.Size > 0 ? action.Size : 10;
        var page = action.Page > 0 ? action.Page : 1;
        var skip = (page - 1) * pageSize;

        var jobPosts = await query
            .Skip(skip)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        var jobPostDtos = jobPosts.Select(jp => new JobPostDto
        {
            Id = jp.Id,
            Title = jp.JobTitle,
            Description = jp.Description,
            Location = jp.JobLocation,
            CompanyId = jp.CompanyProfileId,
            JopType = jp.Type,
            DateToPost = jp.DatePosted,
            DateToExpire = jp.ExpirationDate,
            CompensationDetails = jp.CompensationDetails,
            SalaryOffered = jp.SalaryOffered,
            UseCpccApply = jp.UseCpccApplyNow,
            ApplyUrl = jp.ApplyUrl,
            IsActive = jp.IsActive,
            JobRequirementGroups = jp.RequirementGroups?.Select(rg => new JobRequirementGroupDto
            {
                Id = rg.Id,
                Label = rg.Label,
                Order = rg.Order,
                JobPostId = rg.JobPostId
            }).ToList() ?? new List<JobRequirementGroupDto>(),
            JobBenefits = jp.Benefits?.Select(b => new JobBenefitDto
            {
                Id = b.Id,
                Text = b.Text,
                JopPostId = b.JobPostId
            }).ToList() ?? new List<JobBenefitDto>(),
            Questions = jp.Questions?.Select(q => new ApplicationQuestionDto
            {
                Id = q.Id,
                Text = q.Text,
                JobPostId = q.JobPostId
            }).ToList() ?? new List<ApplicationQuestionDto>()
        }).ToList();

        _logger.LogInformation("Searched job posts: {Count} results (Page {Page}, Size {PageSize})",
            jobPostDtos.Count, page, pageSize);

        return new SearchJobPostsResult(request.RequestId, jobPostDtos);
    }
}
