namespace Adboard.Contracts.Subcategories;

public class UpdateSubcategoryDto
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public string Title { get; set; }
}