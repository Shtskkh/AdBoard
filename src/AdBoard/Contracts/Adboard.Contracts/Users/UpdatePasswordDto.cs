namespace Adboard.Contracts.Users;

/// <summary>
/// Модель обновления пароля пользователя
/// </summary>
public class UpdatePasswordDto
{
    /// <summary>
    /// Id пользователя
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Старый пароль
    /// </summary>
    public string OldPassword { get; set; }
    
    /// <summary>
    /// Новый пароль
    /// </summary>
    public string NewPassword { get; set; }
}