using Adboard.Contracts.Categories;
using FluentValidation;

namespace Adboard.AppServices.Validators.Categories;

public class CreateCategoryValidator : AbstractValidator<CreateCategoryDto>
{
    public CreateCategoryValidator()
    {
        RuleFor(x => x.Title)
            .NotNull()
            .NotEmpty()
            .WithMessage("Title cannot be empty.");
    }
}