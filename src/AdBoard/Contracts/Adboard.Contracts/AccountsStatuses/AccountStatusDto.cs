namespace Adboard.Contracts.AccountsStatuses;

/// <summary>
/// Модель статуса аккаунта
/// </summary>
public class AccountStatusDto
{
    /// <summary>
    /// ID статуса аккаунта
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Название статуса аккаунта
    /// </summary>
    public string Title { get; set; }
}