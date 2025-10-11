using Adboard.Domain.SeedWorks;

namespace Adboard.Domain.Entities;

/// <summary>
/// Сущность комментария 
/// </summary>
public class AdvertComment : IEntity<Guid>
{
    /// <summary>
    /// Первичный ключ
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Текст комментария
    /// </summary>
    public string Text { get; set; }
    
    /// <summary>
    /// Дата создания комментария
    /// </summary>
    public DateTime CreatedAt { get; set; }
    
    // FKs
    /// <summary>
    /// ID пользователя, написавшего комментарий
    /// </summary>
    public Guid UserId { get; set; }
    
    /// <summary>
    /// ID объявления, под которым был написано комментарий
    /// </summary>
    public Guid AdvertId { get; set; }
    
    // Navigation Properties
    /// <summary>
    /// Пользователь, написавший комментарий
    /// </summary>
    public User User { get; set; }
    
    /// <summary>
    /// Объявление, под которым был написан комментарий
    /// </summary>
    public Advert Advert { get; set; }
}