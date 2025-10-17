using Adboard.Domain.SeedWorks;

namespace Adboard.Domain.Entities;

/// <summary>
/// Сущность объявления
/// </summary>
public class Advert : IEntity<Guid>
{
    /// <summary>
    /// Первичный ключ
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Название объявление
    /// </summary>
    public string Title { get; set; }
    
    /// <summary>
    /// Описание объявления
    /// </summary>
    public string Description { get; set; }
    
    /// <summary>
    /// Guid фото, выступающего в качестве превью объявления
    /// </summary>
    // public Guid PreviewPhoto { get; set; }
    
    /// <summary>
    /// Цена товара
    /// </summary>
    public double Price { get; set; }
    
    /// <summary>
    /// Дата создания объявления
    /// </summary>
    public DateTime CreatedAt { get; set; }
    
    // FKs
    /// <summary>
    /// ID пользователя, создавшего объявления
    /// </summary>
    public Guid UserId { get; set; }

    // Navigation Properties
    /// <summary>
    /// Пользователь, создавший объявление
    /// </summary>
    public User User { get; set; }
    
    /// <summary>
    /// Фото объявления
    /// </summary>
    public ICollection<AdvertPhoto> Photos { get; set; }
    
    /// <summary>
    /// Подкатегории, к которому относится объявление
    /// </summary>
    public ICollection<Subcategory> Subcategories { get; set; }
    
    /// <summary>
    /// Комментарии, оставленные под объявлением
    /// </summary>
    public ICollection<AdvertComment> AdvertComments { get; set; }
}