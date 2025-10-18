namespace Adboard.Contracts.Users;

/// <summary>
/// Модель обновления пользователя
/// </summary>
public class UpdateUserDto
{
    /// <summary>
    /// Id пользователя
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Имя
    /// </summary>
    public string? FirstName { get; set; }
    
    /// <summary>
    /// Отчество
    /// </summary>
    public string? MiddleName { get; set; }
    
    /// <summary>
    /// Фамилия
    /// </summary>
    public string? LastName { get; set; }
    
    /// <summary>
    /// Статус аккаунта
    /// </summary>
    public int? AccountStatusId { get; set; }
    
    /// <summary>
    /// Роль
    /// </summary>
    public int? RoleId { get; set; }
}