using Adboard.Contracts.AccountsStatuses;

namespace Adboard.AppServices.Contexts.AccountsStatuses.Services;

public interface IAccountStatusService
{
    Task<IReadOnlyCollection<AccountStatusDto>> GetAllAsync();
    Task<AccountStatusDto?> GetByIdAsync(int id);
    Task<AccountStatusDto?> GetByTitleAsync(string title);
}