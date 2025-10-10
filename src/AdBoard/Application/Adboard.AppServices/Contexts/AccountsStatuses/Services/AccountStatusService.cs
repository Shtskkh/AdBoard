using Adboard.AppServices.Contexts.AccountsStatuses.Repositories;
using Adboard.Contracts.AccountsStatuses;

namespace Adboard.AppServices.Contexts.AccountsStatuses.Services;

public class AccountStatusService(IAccountStatusRepository repository) : IAccountStatusService
{
    public async Task<IReadOnlyCollection<AccountStatusDto>> GetAllAsync()
    {
        var statuses = await repository.GetAllAsync();
        var statusesDto = statuses.Select(s => new AccountStatusDto
        {
            Id = s.Id,
            Title = s.Title,
        });
        
        return statusesDto.ToList().AsReadOnly();
    }

    public async Task<AccountStatusDto?> GetByIdAsync(int id)
    {
        var status = await repository.GetByIdAsync(id);
        if (status == null)
        {
            return null;
        }

        var statusDto = new AccountStatusDto
        {
            Id = status.Id,
            Title = status.Title,
        };
        
        return statusDto;
    }

    public async Task<AccountStatusDto?> GetByTitleAsync(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("Title is null or empty");
        }
        
        var status = await repository.GetByTitleAsync(title);
        if (status == null)
        {
            return null;
        }

        var statusDto = new AccountStatusDto
        {
            Id = status.Id,
            Title = status.Title,
        };
        
        return statusDto;
    }
}