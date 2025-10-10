using Adboard.Domain.Entities;

namespace Adboard.AppServices.Contexts.AccountsStatuses.Repositories;

public interface IAccountStatusRepository
{
    Task<IReadOnlyCollection<AccountStatus>> GetAllAsync();
    Task<AccountStatus> GetByIdAsync(int id);
    Task<AccountStatus> GetByTitleAsync(string title);
}