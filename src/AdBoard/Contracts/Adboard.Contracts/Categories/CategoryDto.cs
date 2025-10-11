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
    public string Title { get; set; }
}