using Adboard.Contracts.Categories;

namespace Adboard.Contracts.Adverts;

public class CreateAdvertDto
{
    public Guid UserId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public IReadOnlyCollection<SelectCategoryDto> Categories { get; set; }
    // public IReadOnlyCollection<FileDto> Photos { get; set; }
}