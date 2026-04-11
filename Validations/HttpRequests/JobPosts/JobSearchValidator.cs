using FluentValidation;
using ViewModels.HttpRequests.JobPosts;

namespace Validation.HttpRequests.JobPosts;

public class JobSearchValidator: AbstractValidator<SearchJobsAction>
{
    public const string LocationDistanceRule = nameof(LocationDistanceRule);
    public const string LocationDistanceRuleText = "You must set a distance from the loacation ented when searching by location";
    
    public JobSearchValidator()
    {
        RuleFor(x => x.Page)
            .GreaterThan(0);

        RuleFor(x => x.Size)
            .GreaterThan(0);
    }
    
}