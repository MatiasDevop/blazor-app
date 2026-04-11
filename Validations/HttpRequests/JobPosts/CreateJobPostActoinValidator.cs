using FluentValidation;
using ViewModels.HttpRequests.JobPosts;

namespace Validation.HttpRequests.JobPosts;

public class CreateJobPostActionValidator: AbstractValidator<CreateJobPostAction>
{
    public CreateJobPostActionValidator()
    {
        
        RuleFor(obj => obj.Description)
            .NotNull()
            .NotEmpty();

        RuleFor(obj => obj.Location)
            .NotNull()
            .NotEmpty();

        RuleFor(obj => obj.RecruiterId)
            .NotNull()
            .NotEmpty();

        RuleFor(obj => obj.Title)
            .NotNull()
            .NotEmpty();

        RuleFor(obj => obj.ApplyUrl)
            .Must((action, s) =>
            {
                if (action.UseCpccApply == false)
                {
                    return !string.IsNullOrWhiteSpace(s);
                }

                return string.IsNullOrWhiteSpace(s);
            })
            .WithName("ApplyUrl Required when not using CpccApplyNow")
            .WithMessage("When you are not using CPCC Apply Now you must have a valid ApplyURl, otherwise the Apply URL should bot be provided.");

        RuleFor(obj => obj.JopType)
            .NotNull();

        RuleFor(obj => obj.SalaryOffered)
            .NotNull()
            .NotEmpty();

        RuleFor(obj => obj.DateToExpire)
            .GreaterThan(DateTime.Now)
            .GreaterThan(obj => obj.DateToPost);

        RuleFor(obj => obj.DateToPost)
            .GreaterThan(DateTime.Today - TimeSpan.FromDays(1));
    }
}