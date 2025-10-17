using Adboard.AppServices.Contexts.Users.Repositories;
using Adboard.AppServices.Contexts.Users.Specifications;
using Adboard.Contracts.Users;
using AutoMapper;

namespace Adboard.AppServices.Contexts.Users.Services;

public class UserService(IUserRepository repository, IMapper mapper) : IUserService
{
    public async Task<UserDto> GetByIdAsync(Guid id)
    {
        var user = await repository.GetByIdAsync(id);
        var dto = mapper.Map<UserDto>(user);
        
        return dto;
    }

    public async Task<IReadOnlyCollection<UserDto>> GetByFilterAsync(UserFilterDto filter)
    {
        var specification = new UserFilterSpecification(filter);
        var users = await repository.GetByFilterAsync(specification);
        var dto = mapper.Map<IReadOnlyCollection<UserDto>>(users);
        
        return dto;
    }

    public async Task<UserAuthInfoDto> GetAuthInfoAsync(Guid id)
    {
        var user = await repository.GetByIdAsync(id);
        var dto = mapper.Map<UserAuthInfoDto>(user);
        
        return dto;
    }

    public async Task<Guid> AddAsync(CreateUserDto createDto)
    {
        return await repository.AddAsync(createDto);
    }

    public async Task<UserDto> UpdateAsync(UpdateUserDto updateDto)
    {
        var updatedUser = await repository.UpdateAsync(updateDto);
        var dto = mapper.Map<UserDto>(updatedUser);
        
        return dto;
    }

    public async Task UpdatePasswordAsync(Guid id, string newPassword)
    {
        await repository.UpdatePasswordAsync(id, newPassword);
    }
}