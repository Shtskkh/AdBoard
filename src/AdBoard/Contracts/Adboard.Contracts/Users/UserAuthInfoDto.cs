namespace Adboard.Contracts.Users;

/// <summary>
/// Модель аутентификационных данных пользователя
/// </summary>
public class UserAuthInfoDto
{
    /// <summary>
    /// Id пользователя
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Почта
    /// </summary>
    public string Email { get; set; }
    
    /// <summary>
    /// Пароль
    /// </summary>
    public string Password { get; set; }
}