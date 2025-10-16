using Adboard.AppServices.Contexts.Users.Services;
using Adboard.AppServices.Utilities.Passwords;
using Adboard.AppServices.Utilities.Tokens;
using Adboard.Contracts.Users;
using Adboard.Domain.Enums;

namespace Adboard.AppServices.Facades.Users;

public class UserFacade(IUserService userService, IPasswordHasher hashService, ITokenService tokenService) : IUserFacade
{
    public async Task<string> RegisterUserAsync(CreateUserDto createDto)
    {
        createDto.Password = hashService.HashPassword(createDto.Password);
        
        var userGuid = await userService.AddAsync(createDto);
        
        return tokenService.GenerateEmailConfirmationToken(userGuid);
    }

    public async Task VerifyUserAsync(string token)
    {
        var guid = await tokenService.VerifyEmailConfirmationTokenAsync(token);
        var updateUser = new UpdateUserDto
        {
            Id = Guid.Parse(guid),
            AccountStatusId = (int)AccountStatusType.Active
        };
        
        await userService.UpdateAsync(updateUser);
    }

    public async Task<UserDto> GetByIdAsync(Guid id)
    {
        return await userService.GetByIdAsync(id);
    }

    public async Task<IReadOnlyCollection<UserDto>> GetByFilterAsync(UserFilterDto filter)
    {
        return await userService.GetByFilterAsync(filter);
    }

    public async Task<Guid> AddAsync(CreateUserDto createDto)
    {
        return await userService.AddAsync(createDto);
    }

    public async Task<UserDto> UpdateAsync(UpdateUserDto updateDto)
    {
        return await userService.UpdateAsync(updateDto);
    }

    public async Task UpdatePasswordAsync(UpdateUserDto dto)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateEmailAsync(Guid id, string email)
    {
        throw new NotImplementedException();
    }
}