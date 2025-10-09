using Adboard.Contracts.AccountsStatuses;

namespace Adboard.AppServices.Contexts.AccountsStatuses.Services;

public interface IAccountStatusService
{
    Task<IReadOnlyCollection<AccountStatusDto>> GetAllAsync();
    Task<int> AddAsync(CreateAccountStatusDto dto);
}