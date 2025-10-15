using Adboard.AppServices.Contexts.Roles.Repositories;
using Adboard.AppServices.Exceptions;
using Adboard.Domain.Entities;
using Adboard.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Adboard.Infrastructure.DataAccess.Context.Roles.Repositories;

/// <summary>
/// Репозиторий ролей
/// </summary>
/// <param name="repository">Базовый репозиторий ролей</param>
public class RoleRepository
    (IRepository<Role, int, ApplicationDbContext> repository): IRoleRepository
{
    /// <summary>
    /// Получить все роли
    /// </summary>
    /// <returns>Массив сущностей ролей</returns>
    public async Task<IReadOnlyCollection<Role>> GetAllAsync()
    {
        var roles = await repository.GetAllAsync()
            .OrderBy(a => a.Id)
            .ToListAsync();
        return roles.AsReadOnly();
    }

    /// <summary>
    /// Получить роль по id
    /// </summary>
    /// <param name="id">Id роли</param>
    /// <returns>Сущность ролей</returns>
    /// <exception cref="NotFoundException">Роль не найдена</exception>
    public async Task<Role> GetByIdAsync(int id)
    {
        return await repository.GetByIdAsync(id) ?? throw new NotFoundException(notFoundMessage:
            $"Role with id: {id} not found.");
    }

    /// <summary>
    /// Получить роль по названию
    /// </summary>
    /// <param name="title">Название роли</param>
    /// <returns>Сущность найденной роли</returns>
    /// <exception cref="NotFoundException">Роль не найдена</exception>
    public async Task<Role> GetByTitleAsync(string title)
    {
        var role = await repository.GetAllAsync()
            .Where(r => r.Title == title)
            .FirstOrDefaultAsync();

        return role ?? throw new NotFoundException(notFoundMessage: $"Role with title: {title} not found.");
    }
}