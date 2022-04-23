using FluentValidation;
using KingdomServerManager.Shared.Models.Requests;

namespace KingdomServerManager.BusinessLayer.Validators;

public class SaveUserRequestValidator : AbstractValidator<SaveUserRequest>
{
    public SaveUserRequestValidator()
    {
        RuleFor(u => u.UserName)
            .NotNull()
            .NotEmpty()
            .WithMessage("you must provide a username");

        RuleFor(u => u.IdRole)
            .NotEmpty()
            .WithMessage("you must provide the id of the user");
    }
}