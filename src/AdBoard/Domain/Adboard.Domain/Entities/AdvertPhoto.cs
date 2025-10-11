using Adboard.Domain.SeedWorks;

namespace Adboard.Domain.Entities;

/// <summary>
/// Сущность фото объявления
/// </summary>
public class AdvertPhoto : IEntity<Guid>
{
    /// <summary>
    /// Первичный ключ
    /// </summary>
    public Guid Id { get; set; }
    
    // FKs
    /// <summary>
    /// ID объявления, к которому относится фото
    /// </summary>
    public Guid AdvertId { get; set; }
    
    // Navigation Properties
    /// <summary>
    /// Объявление, к которому относится фото
    /// </summary>
    public Advert Advert { get; set; }
}