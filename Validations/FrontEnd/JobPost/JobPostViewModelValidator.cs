using FluentValidation;
using ViewModels.Dtos;

namespace Validation.FrontEnd.JobPost;

public class JobPostViewModelValidator : AbstractValidator<JobPostDto>
{
    public JobPostViewModelValidator()
    {
        RuleFor(vm => vm.Title)
            .NotEmpty().WithMessage("Job Title Cannot Be Empty");

        RuleFor(vm => vm.Location)
            .NotEmpty().WithMessage("Job Location Cannot Be Empty");

        RuleFor(vm => vm.JopType)
            .NotNull().WithMessage("You Must Select a Job Type");

        RuleFor(vm => vm.RecruiterId)
            .Must(i => i != Guid.Empty).WithMessage("You Must Select a Recruiter. You May Manage Roles under User Manager in Your Company Profile.");

        RuleFor(vm => vm.DateToPost)
            .NotEmpty()
            .Must(PastAllowedValue).WithMessage("Past Date Is Not Allowed")
            .LessThan(x => x.DateToExpire).WithMessage("Date Entered Must Be Less than Date to Expire");

        RuleFor(vm => vm.DateToExpire)
            .NotEmpty()
            .GreaterThan(x => x.DateToPost).WithMessage("Date Entered Has to Be Greater than Date to Post");

        RuleFor(vm => vm.Description)
            .NotEmpty().WithMessage("Job Description Cannot Be Empty");

        RuleFor(vm => vm.CompensationDetails)
            .NotEmpty().WithMessage("Compensation Details Cannot Be Empty");

        RuleFor(vm => vm.SalaryOffered)
            .NotEmpty().WithMessage("Salary Offered Field Must Not Be Empty")
            .MaximumLength(30).WithMessage("The Length of Salary Offered Field Must Be 30 Characters or Fewer");

        RuleFor(vm => vm.ApplyUrl)
            .Must((action, s) =>
            {
                return action.UseCpccApply || !string.IsNullOrWhiteSpace(action.ApplyUrl);
            }).WithMessage("Apply Url is Required")
            .Must((model, property) =>
            {
                return model.UseCpccApply || BeAValidUrl(model.ApplyUrl);
            }).WithMessage("URL is not Valid");

    }

    private bool PastAllowedValue(DateTime date)
    {
        var currentDate = DateTime.Now;

        if (date.Date < currentDate.Date)
        {
            return false;
        }

        return true;
    }

    private static bool BeAValidUrl(string arg)
    {
        Uri result;
        return Uri.TryCreate(arg, UriKind.Absolute, out result);
    }
}