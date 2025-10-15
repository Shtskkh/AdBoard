using Adboard.Contracts.Users;

namespace Adboard.AppServices.Contexts.Users.Services;

public interface IUserService
{
    Task<UserDto> GetByIdAsync(Guid id);
    Task<IReadOnlyCollection<UserDto>> GetByFilterAsync(UserFilterDto filter);
    Task<Guid> AddAsync(CreateUserDto dto);
    Task<UserDto> UpdateAsync(UpdateUserDto dto);
}