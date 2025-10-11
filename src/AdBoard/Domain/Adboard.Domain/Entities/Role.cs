using Adboard.Domain.SeedWorks;

namespace Adboard.Domain.Entities;

/// <summary>
/// Сущность роли пользователя
/// </summary>
public class Role : IEntity<int>
{
    /// <summary>
    /// Первичный ключ
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Название роли
    /// </summary>
    public string Title { get; set; }
    
    // Navigation properties
    /// <summary>
    /// Все пользователи, относящиеся к роли
    /// </summary>
    public ICollection<User> Users { get; set; }
}