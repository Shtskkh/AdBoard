namespace Adboard.Contracts.Categories;

/// <summary>
/// Модель обновления категории
/// </summary>
public class UpdateCategoryDto
{
    /// <summary>
    /// ID категории
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Новое название категории
    /// </summary>
    public string Title { get; set; }
}