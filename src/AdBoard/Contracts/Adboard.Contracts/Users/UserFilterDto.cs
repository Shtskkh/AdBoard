using Adboard.Contracts.Base;

namespace Adboard.Contracts.Users;

/// <summary>
/// Модель поиска пользователей по фильтру
/// </summary>
public class UserFilterDto : IPagination
{
    /// <summary>
    /// Имя
    /// </summary>
    public string? FirstName { get; set; }
    
    /// <summary>
    /// Фамилия
    /// </summary>
    public string? MiddleName { get; set; }
    
    /// <summary>
    /// Фамилия
    /// </summary>
    public string? LastName { get; set; }
    
    /// <summary>
    /// Номер телефона
    /// </summary>
    public string? PhoneNumber { get; set; }
    
    /// <summary>
    /// Почта
    /// </summary>
    public string? Email { get; set; }
    
    /// <summary>
    /// Роль
    /// </summary>
    public string? Role { get; set; }
    
    /// <summary>
    /// Статус аккаунта
    /// </summary>
    public int? AccountStatus { get; set; }
    
    /// <inheritdoc />
    public int Size { get; set; }
    
    /// <inheritdoc />
    public int Page { get; set; }
}