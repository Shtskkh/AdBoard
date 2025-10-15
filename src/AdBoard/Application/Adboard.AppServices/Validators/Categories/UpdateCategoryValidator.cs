using Adboard.Contracts.Categories;
using FluentValidation;

namespace Adboard.AppServices.Validators.Categories;

public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryDto>
{
    public UpdateCategoryValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Id cannot be less than zero.")
            .NotNull()
            .NotEmpty()
            .WithMessage("Id cannot be empty.");
        
        RuleFor(x => x.Title)
            .NotNull()
            .NotEmpty()
            .WithMessage("Title cannot be empty.");
    }
}