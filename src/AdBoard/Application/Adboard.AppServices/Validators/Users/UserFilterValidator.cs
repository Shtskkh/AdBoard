using Adboard.Contracts.Users;
using FluentValidation;

namespace Adboard.AppServices.Validators.Users;

public class UserFilterValidator : AbstractValidator<UserFilterDto>
{
    public UserFilterValidator()
    {
        RuleFor(x => x.Size)
            .NotNull()
            .GreaterThan(0)
            .LessThanOrEqualTo(100);
        
        RuleFor(x => x.Page)
            .NotNull()
            .GreaterThan(0)
            .LessThanOrEqualTo(100);
    }
}