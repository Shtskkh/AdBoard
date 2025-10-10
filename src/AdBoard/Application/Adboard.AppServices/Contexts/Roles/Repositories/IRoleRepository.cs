using Adboard.Domain.Entities;

namespace Adboard.AppServices.Contexts.Roles.Repositories;

public interface IRoleRepository
{
    Task <IReadOnlyCollection<Role>> GetAllAsync();
    Task <Role> GetByIdAsync(int id);
    Task <Role> GetByTitleAsync(string title);
}