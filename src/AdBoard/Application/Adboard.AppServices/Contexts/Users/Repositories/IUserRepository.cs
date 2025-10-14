using Adboard.Contracts.Users;
using Adboard.Domain.Entities;

namespace Adboard.AppServices.Contexts.Users.Repositories;

public interface IUserRepository
{
    Task<User> GetByEmailAsync(string email); // Todo: переделать на спецификацию
    Task<User> GetByIdAsync(Guid id);
    Task<Guid> AddAsync(CreateUserDto createDto);
    Task<User> UpdateAsync(UpdateUserDto updateDto);
}