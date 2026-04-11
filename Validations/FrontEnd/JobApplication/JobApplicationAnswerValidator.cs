using FluentValidation;
using ViewModels.Dtos;

namespace Validation.FrontEnd.JobApplication;

public class JobApplicationAnswerValidator : AbstractValidator<JobApplicationAnswerDto>
{
    public JobApplicationAnswerValidator()
    {
        RuleFor(vm => vm.AnswerText)
            .NotNull().WithMessage("Answer is required!")
            .NotEmpty().WithMessage("Answer is required!");
    }
}