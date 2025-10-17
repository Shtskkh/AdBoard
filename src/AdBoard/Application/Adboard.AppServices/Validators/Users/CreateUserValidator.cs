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
            .EmailAddress()
            .WithMessage("Email is invalid.");
        
        RuleFor(x => x.Password)
            .NotNull()
            .NotEmpty()
            .WithMessage("Password is required.")
            .MinimumLength(6)
            .WithMessage("Password must have at least 6 characters.");
        
        RuleFor(x => x.RoleId)
            .NotNull()
            .NotEmpty()
            .GreaterThan(0)
            .WithMessage("RoleId must be greater than zero.");
    }
}