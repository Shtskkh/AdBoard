using Adboard.Contracts.Users;

namespace Adboard.AppServices.Facades.Users;

public interface IUserFacade
{
    Task<string> RegisterUserAsync(CreateUserDto createDto);
    Task VerifyUserAsync(string token);
    Task<UserDto> GetByIdAsync(Guid id);
    Task<IReadOnlyCollection<UserDto>> GetByFilterAsync(UserFilterDto filter);
    Task<Guid> AddAsync(CreateUserDto createDto);
    Task<UserDto> UpdateAsync(UpdateUserDto updateDto);
    Task UpdatePasswordAsync(UpdateUserDto dto);
    Task UpdateEmailAsync(Guid id, string email);
}