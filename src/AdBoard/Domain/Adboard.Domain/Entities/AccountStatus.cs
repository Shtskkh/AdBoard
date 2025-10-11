using Adboard.Domain.SeedWorks;

namespace Adboard.Domain.Entities;

/// <summary>
/// Сущность статуса аккаунта пользователя
/// </summary>
public class AccountStatus : IEntity<int>
{
    /// <summary>
    /// Первичный ключ
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Название статуса аккаунта
    /// </summary>
    public string Title { get; set; }
    
    // Navigation Properties
    /// <summary>
    /// Все пользователи с данным статусом
    /// </summary>
    public ICollection<User> Users { get; set; }
}