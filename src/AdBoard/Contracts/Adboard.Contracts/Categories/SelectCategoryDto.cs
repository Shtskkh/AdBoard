namespace Adboard.Contracts.Categories;

public class SelectCategoryDto
{
    public int CategoryId { get; set; }
    public IReadOnlyCollection<int> Subcategories { get; set; }
}