namespace Adboard.Contracts.Subcategories;

/// <summary>
/// Модель подкатегории
/// </summary>
public class SubcategoryDto
{
    /// <summary>
    /// ID категории, к которой относится подкатегория
    /// </summary>
    public int CategoryId { get; set; }
    
    /// <summary>
    /// Название категории, к которой относится подкатегория
    /// </summary>
    public string CategoryTitle { get; set; }
    
    /// <summary>
    /// ID подкатегории
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Название подкатегории
    /// </summary>
    public string Title { get; set; }
}