using Adboard.AppServices.Contexts.AccountsStatuses.Repositories;
using Adboard.AppServices.Exceptions;
using Adboard.Domain.Entities;
using Adboard.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Adboard.Infrastructure.DataAccess.Context.AccountsStatuses.Repositories;

public class AccountStatusRepository
    (IRepository<AccountStatus, int, ApplicationDbContext> repository) : IAccountStatusRepository
{
    public async Task<IReadOnlyCollection<AccountStatus>> GetAllAsync()
    {
        var accountStatuses = await repository.GetAllAsync()
            .OrderBy(a => a.Id)
            .ToListAsync();
        return accountStatuses.AsReadOnly();
    }

    public async Task<AccountStatus> GetByIdAsync(int id)
    {
        return await repository.GetByIdAsync(id) ?? 
               throw new NotFoundException($"Account status with id: {id} not found");
    }

    // Todo: переделать на массивный результат
    public async Task<AccountStatus> GetByTitleAsync(string title)
    {
        var accountStatus = await repository.GetAllAsync()
            .Where(a => a.Title == title)
            .FirstOrDefaultAsync();
        
        return accountStatus ?? 
               throw new NotFoundException($"Account status with title: {title} not found");;
    }
}