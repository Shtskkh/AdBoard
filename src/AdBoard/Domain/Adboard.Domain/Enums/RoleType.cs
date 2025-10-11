namespace Adboard.Domain.Enums;

/// <summary>
/// Перечисление всех возможных типов ролей пользователей
/// </summary>
public enum RoleType
{
    /// <summary>
    ///  Админ
    /// </summary>
    Admin = 1,
    
    /// <summary>
    /// Модератор
    /// </summary>
    Moderator = 2,
    
    /// <summary>
    /// Обычный пользователь
    /// </summary>
    User = 3
}