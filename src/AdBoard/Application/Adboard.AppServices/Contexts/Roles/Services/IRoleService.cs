using Adboard.Contracts.Roles;
using Adboard.Domain.Entities;

namespace Adboard.AppServices.Contexts.Roles.Services;

public interface IRoleService
{
    Task<IReadOnlyCollection<RoleDto>> GetAllAsync();
    Task<RoleDto> GetByIdAsync(int id);
    Task<RoleDto> GetByTitleAsync(string title);
}