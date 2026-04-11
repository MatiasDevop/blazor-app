using MediatR;
using Microsoft.EntityFrameworkCore;
using Portal.Api.Data;
using Domain.Entities;
using ViewModels.Requests.Endpoints.JobPosts;

namespace Portal.Api.Handlers.JobPosts;

public class UpdateJobPostHandler : IRequestHandler<UpdateJobPostRequest, UpdateJobPostResult>
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<UpdateJobPostHandler> _logger;

    public UpdateJobPostHandler(ApplicationDbContext context, ILogger<UpdateJobPostHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<UpdateJobPostResult> Handle(UpdateJobPostRequest request, CancellationToken cancellationToken)
    {
        var action = request.UpdateJob;

        using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
        try
        {
            // Load existing job post with nested entities
            var jobPost = await _context.JobPosts
                .Include(jp => jp.RequirementGroups)
                .Include(jp => jp.Benefits)
                .Include(jp => jp.Questions)
                .FirstOrDefaultAsync(jp => jp.Id == action.Id, cancellationToken);

            if (jobPost == null)
            {
                _logger.LogWarning("Job post {JobPostId} not found for update", action.Id);
                throw new KeyNotFoundException($"Job post with ID {action.Id} not found");
            }

            // Update scalar properties
            jobPost.JobTitle = action.Title;
            jobPost.Description = action.Description;
            jobPost.JobLocation = action.Location;
            jobPost.CompensationDetails = action.CompensationDetails;
            jobPost.SalaryOffered = action.SalaryOffered;
            jobPost.UseCpccApplyNow = action.UseCpccApply;
            jobPost.ApplyUrl = action.ApplyUrl;
            jobPost.Type = action.JopType;
            jobPost.DatePosted = action.DateToPost;
            jobPost.ExpirationDate = action.DateToExpire;
            jobPost.IsActive = action.IsActive;
            jobPost.UpdatedAt = DateTime.UtcNow;

            // Update requirement groups
            if (action.JobRequirementGroups != null)
            {
                // Remove deleted groups
                var incomingGroupIds = action.JobRequirementGroups
                    .Where(g => g.Id != Guid.Empty)
                    .Select(g => g.Id)
                    .ToList();

                var groupsToRemove = jobPost.RequirementGroups
                    .Where(g => !incomingGroupIds.Contains(g.Id))
                    .ToList();

                _context.JobRequirementGroups.RemoveRange(groupsToRemove);

                // Update existing and add new groups
                foreach (var groupDto in action.JobRequirementGroups)
                {
                    if (groupDto.Id == Guid.Empty)
                    {
                        // Add new group
                        var newGroup = new JobRequirementGroup
                        {
                            Id = Guid.NewGuid(),
                            Name = groupDto.Label,
                            Label = groupDto.Label,
                            Order = groupDto.Order,
                            JobPostId = jobPost.Id
                        };
                        _context.JobRequirementGroups.Add(newGroup);
                    }
                    else
                    {
                        // Update existing group
                        var existingGroup = jobPost.RequirementGroups
                            .FirstOrDefault(g => g.Id == groupDto.Id);
                        if (existingGroup != null)
                        {
                            existingGroup.Label = groupDto.Label;
                            existingGroup.Name = groupDto.Label;
                            existingGroup.Order = groupDto.Order;
                        }
                    }
                }
            }

            // Update benefits
            if (action.JobBenefits != null)
            {
                // Remove deleted benefits
                var incomingBenefitIds = action.JobBenefits
                    .Where(b => b.Id != Guid.Empty)
                    .Select(b => b.Id)
                    .ToList();

                var benefitsToRemove = jobPost.Benefits
                    .Where(b => !incomingBenefitIds.Contains(b.Id))
                    .ToList();

                _context.JobBenefits.RemoveRange(benefitsToRemove);

                // Update existing and add new benefits
                foreach (var benefitDto in action.JobBenefits)
                {
                    if (benefitDto.Id == Guid.Empty)
                    {
                        // Add new benefit
                        var newBenefit = new JobBenefit
                        {
                            Id = Guid.NewGuid(),
                            Text = benefitDto.Text,
                            Name = benefitDto.Text,
                            JobPostId = jobPost.Id
                        };
                        _context.JobBenefits.Add(newBenefit);
                    }
                    else
                    {
                        // Update existing benefit
                        var existingBenefit = jobPost.Benefits
                            .FirstOrDefault(b => b.Id == benefitDto.Id);
                        if (existingBenefit != null)
                        {
                            existingBenefit.Text = benefitDto.Text;
                            existingBenefit.Name = benefitDto.Text;
                        }
                    }
                }
            }

            // Update questions
            if (action.Questions != null)
            {
                // Remove deleted questions
                var incomingQuestionIds = action.Questions
                    .Where(q => q.Id != Guid.Empty)
                    .Select(q => q.Id)
                    .ToList();

                var questionsToRemove = jobPost.Questions
                    .Where(q => !incomingQuestionIds.Contains(q.Id))
                    .ToList();

                _context.ApplicationQuestions.RemoveRange(questionsToRemove);

                // Update existing and add new questions
                foreach (var questionDto in action.Questions)
                {
                    if (questionDto.Id == Guid.Empty)
                    {
                        // Add new question
                        var newQuestion = new ApplicationQuestion
                        {
                            Id = Guid.NewGuid(),
                            Text = questionDto.Text,
                            Question = questionDto.Text,
                            JobPostId = jobPost.Id
                        };
                        _context.ApplicationQuestions.Add(newQuestion);
                    }
                    else
                    {
                        // Update existing question
                        var existingQuestion = jobPost.Questions
                            .FirstOrDefault(q => q.Id == questionDto.Id);
                        if (existingQuestion != null)
                        {
                            existingQuestion.Text = questionDto.Text;
                            existingQuestion.Question = questionDto.Text;
                        }
                    }
                }
            }

            await _context.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);

            _logger.LogInformation("Job post {JobPostId} updated successfully", jobPost.Id);

            return new UpdateJobPostResult(request.RequestId, action);
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(cancellationToken);
            _logger.LogError(ex, "Error updating job post {JobPostId}", action.Id);
            throw;
        }
    }
}
