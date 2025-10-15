using Adboard.Contracts.Base;

namespace Adboard.Contracts.Users;

/// <summary>
/// Модель поиска пользователей по фильтру
/// </summary>
public class UserFilterDto : IPagination
{
    public string? FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string? LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? Role { get; set; }
    public int? AccountStatus { get; set; }
    public int Size { get; set; }
    public int Page { get; set; }
}