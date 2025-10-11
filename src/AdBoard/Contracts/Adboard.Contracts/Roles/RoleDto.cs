namespace Adboard.Contracts.Roles;

/// <summary>
/// Модель роли пользователя
/// </summary>
public class RoleDto
{
    /// <summary>
    /// ID роли
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Название роли
    /// </summary>
    public string Title { get; set; }
}