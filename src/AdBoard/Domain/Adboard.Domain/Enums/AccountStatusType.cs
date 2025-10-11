namespace Adboard.Domain.Enums;

/// <summary>
/// Перечисление для всех возможных статусов аккаунтов у пользователей 
/// </summary>
public enum AccountStatusType
{
    /// <summary>
    /// Аккаунт требует подтверждения
    /// </summary>
    NeedsConfirm = 1,
    
    /// <summary>
    /// Аккаунт активен
    /// </summary>
    Active = 2,
    
    /// <summary>
    /// Аккаунт заблокирован
    /// </summary>
    Blocked = 3,
    
    /// <summary>
    /// Аккаунт удалён
    /// </summary>
    Deleted = 4
}