using FluentValidation;
using KingdomServerManager.Shared.Models.Requests;

namespace KingdomServerManager.BusinessLayer.Validators;

public class SaveLogRequestValidator : AbstractValidator<SaveLogRequest>
{
    public SaveLogRequestValidator()
    {
        RuleFor(l => l.IdUser)
            .NotEmpty()
            .WithMessage("you must provide a valid user");

        RuleFor(l => l.Title)
            .NotNull()
            .NotEmpty()
            .MaximumLength(100)
            .WithMessage("you must provide a title");

        RuleFor(l => l.Description)
            .NotNull()
            .NotEmpty()
            .MaximumLength(512)
            .WithMessage("you must provide a description");
    }
}