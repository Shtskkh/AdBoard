namespace Adboard.Contracts.Subcategories;

/// <summary>
/// Модель обновления подкатегории
/// </summary>
public class UpdateSubcategoryDto
{
    /// <summary>
    /// ID подкатегории
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// ID категории, к которой относится подкатегория
    /// </summary>
    public int CategoryId { get; set; }
    
    /// <summary>
    /// Новое название подкатегории
    /// </summary>
    public string Title { get; set; }
}