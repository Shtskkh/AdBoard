using Adboard.AppServices.Contexts.AccountsStatuses.Repositories;
using Adboard.Contracts.AccountsStatuses;
using Adboard.Domain.Entities;

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

    public async Task<int> AddAsync(CreateAccountStatusDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Title))
        {
            throw new ArgumentException("Title is required");
        }
        
        var status = new AccountStatus
        {
            Title = dto.Title
        };
        
        var id = await repository.AddAsync(status);
        
        return id;
    }
}