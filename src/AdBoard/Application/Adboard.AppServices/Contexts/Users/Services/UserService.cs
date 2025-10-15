using Adboard.AppServices.Contexts.Users.Repositories;
using Adboard.AppServices.Contexts.Users.Specifications;
using Adboard.Contracts.Users;
using Adboard.Domain.Entities;
using AutoMapper;

namespace Adboard.AppServices.Contexts.Users.Services;

public class UserService(IUserRepository repository, IMapper mapper) : IUserService
{
    public async Task<UserDto> GetByIdAsync(Guid id)
    {
        var user = await repository.GetByIdAsync(id);

        var dto = new UserDto
        {
            Id = user.Id,
            FirstName = user.FirstName,
            MiddleName = user.MiddleName ?? null,
            LastName = user.LastName,
            PhoneNumber = user.PhoneNumber ?? null,
            Email = user.Email,
            Role = user.Role.Title,
            AccountStatus = user.AccountStatus.Title
        };
        
        return dto;
    }

    public async Task<IReadOnlyCollection<UserDto>> GetByFilterAsync(UserFilterDto filter)
    {
        var specification = new UserFilterSpecification(filter);
        var users = await repository.GetByFilterAsync(specification);
        var dto = mapper.Map<IReadOnlyCollection<User>, IReadOnlyCollection<UserDto>>(users);
        return dto;
    }

    public async Task<Guid> AddAsync(CreateUserDto createDto)
    {
        return await repository.AddAsync(createDto);
    }

    public async Task<UserDto> UpdateAsync(UpdateUserDto updateDto)
    {
        var updatedUser = await repository.UpdateAsync(updateDto);
        var dto = mapper.Map<User, UserDto>(updatedUser);
        return dto;
    }
}