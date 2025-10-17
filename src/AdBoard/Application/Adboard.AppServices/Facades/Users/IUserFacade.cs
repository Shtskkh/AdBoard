using Adboard.Contracts.Users;

namespace Adboard.AppServices.Facades.Users;

public interface IUserFacade
{
    Task<string> RegisterUserAsync(CreateUserDto createDto);
    Task VerifyUserAsync(string token);
    Task<UserDto> GetByIdAsync(Guid id);
    Task<IReadOnlyCollection<UserDto>> GetByFilterAsync(UserFilterDto filter);
    Task<UserDto> UpdateAsync(UpdateUserDto updateDto);
    Task UpdatePasswordAsync(UpdatePasswordDto updatePasswordDto);
}