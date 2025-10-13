using Adboard.Contracts.Users;

namespace Adboard.AppServices.Contexts.Users.Services;

public interface IUserService
{
    Task<UserDto> GetByIdAsync(Guid id);
    Task<Guid> AddAsync(CreateUserDto dto);
}