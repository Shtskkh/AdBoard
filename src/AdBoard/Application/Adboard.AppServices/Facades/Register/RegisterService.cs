using Adboard.AppServices.Contexts.Users.Services;
using Adboard.AppServices.Utilities.Passwords;
using Adboard.AppServices.Utilities.Tokens;
using Adboard.Contracts.Users;
using Adboard.Domain.Enums;

namespace Adboard.AppServices.Facades.Register;

public class RegisterService(IUserService userService, IPasswordHasher hashService, ITokenService tokenService) : IRegisterService
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
}