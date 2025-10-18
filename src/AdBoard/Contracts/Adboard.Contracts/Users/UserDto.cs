namespace Adboard.Contracts.Users;

/// <summary>
/// Модель пользователя
/// </summary>
public class UserDto
{
    /// <summary>
    /// Id пользователя
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
    /// Адрес электронной почты
    /// </summary>
    public string Email { get; set; }
    
    /// <summary>
    /// Роль
    /// </summary>
    public string Role { get; set; }
    
    /// <summary>
    /// Статус аккаунта
    /// </summary>
    public string AccountStatus { get; set; }
}