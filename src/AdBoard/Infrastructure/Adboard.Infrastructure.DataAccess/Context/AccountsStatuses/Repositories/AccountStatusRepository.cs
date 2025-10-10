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
        return accountStatuses.AsReadOnly();
    }

    public async Task<AccountStatus?> GetByIdAsync(int id)
    {
        return await repository.GetByIdAsync(id);
    }

    public async Task<AccountStatus?> GetByTitleAsync(string title)
    {
        var accountStatus = await repository.GetAllAsync()
            .Where(a => a.Title == title)
            .FirstOrDefaultAsync();
        
        return accountStatus;
    }
}