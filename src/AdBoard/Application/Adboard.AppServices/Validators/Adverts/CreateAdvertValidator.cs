using Adboard.Contracts.Adverts;
using FluentValidation;

namespace Adboard.AppServices.Validators.Adverts;

public class CreateAdvertValidator : AbstractValidator<CreateAdvertDto>
{
    public CreateAdvertValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .NotNull()
            .WithMessage("Title is required");
        
        RuleFor(x => x.Description)
            .NotEmpty()
            .NotNull()
            .WithMessage("Description is required");
        
        RuleFor(x => x.Price)
            .NotEmpty()
            .NotNull()
            .WithMessage("Price is required")
            .GreaterThan(0.0)
            .WithMessage("Price must be greater than zero");
        
        RuleFor(x => x.SelectedSubcategories)
            .NotEmpty()
            .NotNull()
            .WithMessage("Categories is required")
            .Must(x => x.Count >= 3)
            .WithMessage("Categories must contain at least 3 items");

        RuleForEach(x => x.SelectedSubcategories)
            .ChildRules(child =>
            {
                child.RuleFor(x => x.Subcategories)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("Subcategories is required")
                    .Must(x => x.Count >= 2)
                    .WithMessage("Subcategories must contain at least 2 items");
            });
    }
}