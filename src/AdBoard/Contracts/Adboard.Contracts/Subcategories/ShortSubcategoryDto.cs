namespace Adboard.Contracts.Subcategories;

/// <summary>
/// Модель подкатегории, имеющая только id и название
/// </summary>
public class ShortSubcategoryDto
{
    /// <summary>
    /// Id подкатегории
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Название подкатегории
    /// </summary>
    public string Title { get; set; }
}