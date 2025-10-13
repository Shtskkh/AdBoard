using Adboard.Contracts.Subcategories;

namespace Adboard.Contracts.Categories;

/// <summary>
/// Модель категории
/// </summary>
public class CategoryDto
{
    /// <summary>
    /// ID категории
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Название категории
    /// </summary>
    public required string Title { get; set; }
    
    /// <summary>
    /// Коллекция подкатегорий
    /// </summary>
    public IReadOnlyCollection<ShortSubcategoryDto> Subcategories { get; set; }
}