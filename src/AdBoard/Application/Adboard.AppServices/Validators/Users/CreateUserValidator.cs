using Adboard.Contracts.Users;
using FluentValidation;

namespace Adboard.AppServices.Validators.Users;

public class CreateUserValidator : AbstractValidator<CreateUserDto>
{
    public CreateUserValidator()
    {
        RuleFor(x => x.FirstName)
            .NotNull()
            .NotEmpty()
            .WithMessage("First name is required.");
        
        RuleFor(x => x.LastName)
            .NotNull()
            .NotEmpty()
            .WithMessage("Last name is required.");

        RuleFor(x => x.Email)
            .EmailAddress();
        
        RuleFor(x => x.Password)
            .NotNull()
            .NotEmpty()
            .MinimumLength(6)
            .WithMessage("Password is required.");
        
        RuleFor(x => x.RoleId)
            .GreaterThan(0)
            .WithMessage("RoleId must be greater than zero.");
    }
}