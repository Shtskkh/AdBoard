using Adboard.Domain.SeedWorks;

namespace Adboard.Domain.Entities;

/// <summary>
/// Сущность подкатегории объявления
/// </summary>
public class Subcategory : IEntity<int>
{
    /// <summary>
    /// Первичный ключ
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Название подкатегории
    /// </summary>
    public string Title { get; set; }
    
    // FKs
    /// <summary>
    /// ID категории, к которой пренадлежит подкатегория
    /// </summary>
    public int CategoryId { get; set; }
    
    // Navigation Properties
    /// <summary>
    /// Категория, к которой пренадлежит подкатегория
    /// </summary>
    public Category Category { get; set; }
    
    /// <summary>
    /// Объявления, относящиеся к подкатегории
    /// </summary>
    public ICollection<Advert> Adverts { get; set; }
}