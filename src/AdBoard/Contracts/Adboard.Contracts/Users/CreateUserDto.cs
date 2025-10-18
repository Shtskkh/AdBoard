using Adboard.Domain.Enums;

namespace Adboard.Contracts.Users;

/// <summary>
/// Модель создания пользователя
/// </summary>
public class CreateUserDto
{
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
    /// Пароль
    /// </summary>
    public string Password { get; set; }
    
    /// <summary>
    /// Роль пользователя, по умолчанию User
    /// </summary>
    public int RoleId { get; set; } = (int)RoleType.User;
}