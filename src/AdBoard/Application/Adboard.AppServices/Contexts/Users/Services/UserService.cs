using Adboard.AppServices.Contexts.Users.Repositories;
using Adboard.Contracts.Users;

namespace Adboard.AppServices.Contexts.Users.Services;

public class UserService(IUserRepository repository) : IUserService
{
    public async Task<UserDto> GetByIdAsync(Guid id)
    {
        var user = await repository.GetByIdAsync(id);

        var dto = new UserDto
        {
            Id = user.Id,
            FirstName = user.FirstName,
            MiddleName = user.MiddleName ?? null,
            LastName = user.LastName,
            PhoneNumber = user.PhoneNumber ?? null,
            Email = user.Email,
            Role = user.Role.Title,
            AccountStatus = user.AccountStatus.Title
        };
        
        return dto;
    }

    public async Task<Guid> AddAsync(CreateUserDto dto)
    {
        return await repository.AddAsync(dto);
    }

    public async Task ChangeAccountStatus(string email, int status)
    {
        throw new NotImplementedException();
    }
}