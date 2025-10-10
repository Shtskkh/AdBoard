using Adboard.AppServices.Contexts.Roles.Repositories;
using Adboard.AppServices.Exceptions;
using Adboard.Domain.Entities;
using Adboard.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Adboard.Infrastructure.DataAccess.Context.Roles.Repositories;

public class RoleRepository
    (IRepository<Role, int, ApplicationDbContext> repository): IRoleRepository
{
    public async Task<IReadOnlyCollection<Role>> GetAllAsync()
    {
        var roles = await repository.GetAllAsync().ToListAsync();
        return roles.AsReadOnly();
    }

    public async Task<Role> GetByIdAsync(int id)
    {
        return await repository.GetByIdAsync(id) ?? throw new NotFoundException(notFoundMessage:
            $"Role with id: {id} not found.");
    }

    public async Task<Role> GetByTitleAsync(string title)
    {
        var role = await repository.GetAllAsync()
            .Where(r => r.Title == title)
            .FirstOrDefaultAsync();

        return role ?? throw new NotFoundException(notFoundMessage: $"Role with title: {title} not found.");
    }
}