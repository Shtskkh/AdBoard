namespace Adboard.Contracts.Categories;

/// <summary>
/// Модель выбора категории и подкатегорий
/// </summary>
public class SelectCategoryDto
{
    /// <summary>
    /// Id категории
    /// </summary>
    public int CategoryId { get; set; }
    
    /// <summary>
    /// Массив id подкатегорий
    /// </summary>
    public IReadOnlyCollection<int> Subcategories { get; set; }
}