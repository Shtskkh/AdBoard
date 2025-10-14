using Adboard.Contracts.Users;

namespace Adboard.AppServices.Facades.Register;

public interface IRegisterService
{
    Task<string> RegisterUserAsync(CreateUserDto createDto);
    Task VerifyUserAsync(string token);
}