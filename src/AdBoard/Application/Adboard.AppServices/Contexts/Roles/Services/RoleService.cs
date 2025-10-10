using Adboard.AppServices.Contexts.Roles.Repositories;
using Adboard.Contracts.Roles;

namespace Adboard.AppServices.Contexts.Roles.Services;

public class RoleService(IRoleRepository repository) : IRoleService
{
    public async Task<IReadOnlyCollection<RoleDto>> GetAllAsync()
    {
        var roles = await repository.GetAllAsync();

        var rolesDto = roles.Select(r => new RoleDto
        {
            Id = r.Id,
            Title = r.Title
        });
        
        return rolesDto.ToList().AsReadOnly();
    }

    public async Task<RoleDto> GetByIdAsync(int id)
    {
        var role = await repository.GetByIdAsync(id);

        var roleDto = new RoleDto
        {
            Id = role.Id,
            Title = role.Title
        };
        
        return roleDto;
    }

    public async Task<RoleDto> GetByTitleAsync(string title)
    {
        var role = await repository.GetByTitleAsync(title);

        var roleDto = new RoleDto
        {
            Id = role.Id,
            Title = role.Title
        };
        
        return roleDto;
    }
}