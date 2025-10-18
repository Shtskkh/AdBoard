using Adboard.AppServices.Contexts.AccountsStatuses.Repositories;
using Adboard.AppServices.Exceptions;
using Adboard.Domain.Entities;
using Adboard.Infrastructure.DataAccess.Repositories;
using Adboard.Infrastructure.DataAccess.Repositories.EntitiesRepositories;
using Microsoft.EntityFrameworkCore;

namespace Adboard.Infrastructure.DataAccess.Context.AccountsStatuses.Repositories;

/// <summary>
/// Репозиторий статусов аккаунтов
/// </summary>
/// <param name="repository">Базовый репозиторий статусов аккаунтов</param>
public class AccountStatusRepository
    (IRepository<AccountStatus, int, ApplicationDbContext> repository) : IAccountStatusRepository
{
    /// <summary>
    /// Получить все статусы аккаунтов
    /// </summary>
    /// <returns>Массив сущностей статусов аккаунтов</returns>
    public async Task<IReadOnlyCollection<AccountStatus>> GetAllAsync()
    {
        var accountStatuses = await repository.GetAllAsync()
            .OrderBy(a => a.Id)
            .ToListAsync();
        return accountStatuses.AsReadOnly();
    }

    /// <summary>
    /// Получить статус аккаунта по id
    /// </summary>
    /// <param name="id">Id статуса аккаунта</param>
    /// <returns>Сущность статуса аккаунта</returns>
    /// <exception cref="NotFoundException">Статус аккаунта не найден</exception>
    public async Task<AccountStatus> GetByIdAsync(int id)
    {
        return await repository.GetByIdAsync(id) ?? 
               throw new NotFoundException($"Account status with id: {id} not found");
    }
    
    /// <summary>
    /// Получить статус аккаунта по названию
    /// </summary>
    /// <param name="title">Название статуса аккаунта</param>
    /// <returns>Сущность статуса аккаунта</returns>
    /// <exception cref="NotFoundException">Статус аккаунта не найден</exception>
    public async Task<AccountStatus> GetByTitleAsync(string title)
    {
        var accountStatus = await repository.GetAllAsync()
            .Where(a => a.Title == title)
            .FirstOrDefaultAsync();
        
        return accountStatus ?? 
               throw new NotFoundException($"Account status with title: {title} not found");;
    }
}