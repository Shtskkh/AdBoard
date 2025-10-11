namespace Adboard.Contracts.Categories;

/// <summary>
/// Модель создания категории
/// </summary>
public class CreateCategoryDto
{
    /// <summary>
    /// Название новой категории
    /// </summary>
    public string Title { get; set; }
}