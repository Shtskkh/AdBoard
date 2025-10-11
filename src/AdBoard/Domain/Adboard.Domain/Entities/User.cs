using Adboard.Domain.SeedWorks;

namespace Adboard.Domain.Entities;

/// <summary>
/// Сущность пользователя
/// </summary>
public class User : IEntity<Guid>
{
    /// <summary>
    /// Первичный ключ
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Имя
    /// </summary>
    public string FirstName { get; set; }
    
    /// <summary>
    /// Отчество
    /// </summary>
    public string? MiddleName { get; set; }
    
    /// <summary>
    /// Фамилия
    /// </summary>
    public string LastName { get; set; }
    
    /// <summary>
    /// Номер телефона
    /// </summary>
    public string? PhoneNumber { get; set; }
    
    /// <summary>
    /// Почта
    /// </summary>
    public string Email { get; set; }
    
    /// <summary>
    /// Пароль
    /// </summary>
    public string Password { get; set; }
    
    /// <summary>
    /// Дата создания аккаунта
    /// </summary>
    public DateTime CreatedAt { get; set; }
    
    // FKs
    /// <summary>
    /// Роль пользователя
    /// </summary>
    public int RoleId { get; set; }
    
    /// <summary>
    /// Статус аккаунта пользователя
    /// </summary>
    public int AccountStatusId { get; set; }

    // Navigation Properties
    
    /// <summary>
    /// Роль пользователя
    /// </summary>
    public Role Role { get; set; }
    
    /// <summary>
    /// Статус аккаунта пользователя
    /// </summary>
    public AccountStatus AccountStatus { get; set; }
    
    /// <summary>
    /// Все опубликованные пользователем объявления
    /// </summary>
    public ICollection<Advert> Adverts { get; set; }
    
    /// <summary>
    /// Все написанные пользователем комментарии в объявлениях
    /// </summary>
    public ICollection<AdvertComment> AdvertComments { get; set; }
}