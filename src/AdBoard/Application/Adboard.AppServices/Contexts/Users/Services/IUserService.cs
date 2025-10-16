using Adboard.Contracts.Users;

namespace Adboard.AppServices.Contexts.Users.Services;

public interface IUserService
{
    Task<UserDto> GetByIdAsync(Guid id);
    Task<IReadOnlyCollection<UserDto>> GetByFilterAsync(UserFilterDto filter);
    Task<UserAuthInfoDto> GetAuthInfoAsync(Guid id);
    Task<Guid> AddAsync(CreateUserDto dto);
    Task<UserDto> UpdateAsync(UpdateUserDto dto);
    Task UpdatePasswordAsync(Guid id, string newPassword);
}