using Adboard.Contracts.Users;
using FluentValidation;

namespace Adboard.AppServices.Validators.Users;

public class UpdateUserValidator : AbstractValidator<UpdateUserDto>
{
    public UpdateUserValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEmpty()
            .NotEqual(Guid.Empty)
            .WithMessage("Id cannot be empty.");
    }
}