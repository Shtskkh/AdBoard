using Adboard.AppServices.Contexts.Users.Services;
using Adboard.AppServices.Utilities.Passwords;
using Adboard.AppServices.Utilities.Tokens;
using Adboard.Contracts.Users;

namespace Adboard.AppServices.Facades.Register;

public class RegisterService(IUserService userService, IPasswordHasher hashService, ITokenService tokenService) : IRegisterService
{
    public async Task<string> RegisterUser(CreateUserDto createDto)
    {
        throw new NotImplementedException();
    }
}