using Adboard.AppServices.Contexts.AccountsStatuses.Repositories;
using Adboard.Domain.Entities;
using Adboard.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Adboard.Infrastructure.DataAccess.Context.AccountsStatuses.Repositories;

public class AccountStatusRepository
    (IRepository<AccountStatus, int, ApplicationDbContext> repository) : IAccountStatusRepository
{
    public async Task<IReadOnlyCollection<AccountStatus>> GetAllAsync()
    {
        var accountStatuses = await repository.GetAllAsync().ToListAsync();
        return accountStatuses;
    }

    public async Task<AccountStatus?> GetByIdAsync(int id)
    {
        return await repository.GetByIdAsync(id);
    }

    public async Task<AccountStatus?> GetByTitleAsync(string title)
    {
        var entity = await repository.GetAllAsync()
            .Where(a => a.Title == title)
            .FirstOrDefaultAsync();
        
        return entity;
    }

    public async Task<int> AddAsync(AccountStatus entity)
    {
        var isDuplicate = await GetByTitleAsync(entity.Title) != null;

        if (isDuplicate)
        {
            throw new ArgumentException("Title already exists");
        }
        
        await repository.AddAsync(entity);
        return entity.Id;
    }

    public async Task UpdateAsync(AccountStatus entity)
    {
        await repository.UpdateAsync(entity);
    }

    public async Task<bool> DeleteAsync(AccountStatus entity)
    {
        return await repository.DeleteAsync(entity.Id);
    }
}