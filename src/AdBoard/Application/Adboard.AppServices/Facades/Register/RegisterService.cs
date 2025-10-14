using Adboard.AppServices.Contexts.Users.Services;
using Adboard.AppServices.Utilities.Passwords;
using Adboard.AppServices.Utilities.Tokens;
using Adboard.Contracts.Users;

namespace Adboard.AppServices.Facades.Register;

public class RegisterService(IUserService userService, IPasswordHasher hashService, ITokenService tokenService) : IRegisterService
{
    public async Task<string> RegisterUserAsync(CreateUserDto createDto)
    {
        createDto.Password = hashService.HashPassword(createDto.Password);
        
        await userService.AddAsync(createDto);
        
        return tokenService.GenerateEmailConfirmationToken(createDto.Email);
    }

    public async Task VerifyUserAsync(string token)
    {
        // var email = await tokenService.VerifyEmailConfirmationTokenAsync(token);
        // await userService.VerifyUser(email);
        throw new NotImplementedException();
    }
}