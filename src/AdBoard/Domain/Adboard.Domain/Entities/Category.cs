using Adboard.Domain.SeedWorks;

namespace Adboard.Domain.Entities;

/// <summary>
/// Сущность категории объявления
/// </summary>
public class Category : IEntity<int>
{
    /// <summary>
    /// Первичный ключ
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Название категории объявления
    /// </summary>
    public string Title { get; set; }
    
    // Navigation Properties
    /// <summary>
    /// Все подкатегории, относящиеся к категории
    /// </summary>
    public ICollection<Subcategory> Subcategories { get; set; }
}