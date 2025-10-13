using Adboard.Contracts.Users;

namespace Adboard.AppServices.Facades.Register;

public interface IRegisterService
{
    Task<string> RegisterUser(CreateUserDto createDto);
}