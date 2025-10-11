namespace Adboard.Contracts.Subcategories;

/// <summary>
/// Модель создания подкатегории 
/// </summary>
public class CreateSubcategoryDto
{
    /// <summary>
    /// ID категории, к которой относится подкатегория
    /// </summary>
    public int CategoryId { get; set; }
    
    /// <summary>
    /// Название новой подкатегории
    /// </summary>
    public string Title { get; set; }
}