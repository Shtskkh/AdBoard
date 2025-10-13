using Adboard.AppServices.Contexts.Users.Repositories;
using Adboard.AppServices.Exceptions;
using Adboard.Contracts.Users;
using Adboard.Domain.Entities;
using Adboard.Domain.Enums;
using Adboard.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Adboard.Infrastructure.DataAccess.Context.Users.Repositories;

public class UserRepository
    (IRepository<User, Guid, ApplicationDbContext> repository) : IUserRepository
{
    public async Task<User> GetByIdAsync(Guid id)
    {
        var user = await repository.GetAllAsync()
            .Where(u => u.Id == id)
            .Include(u => u.Role)
            .Include(u => u.AccountStatus)
            .FirstOrDefaultAsync();
        
        return user ?? throw new NotFoundException("User with the given id does not exist.");
    }

    private async Task<bool> IsEmailExisted(string email)
    {
        return await repository.GetAllAsync().AnyAsync(e => e.Email == email);
    }

    private async Task<bool> IsPhoneNumberExisted(string phoneNumber)
    {
        return await repository.GetAllAsync().AnyAsync(e => e.PhoneNumber == phoneNumber);
    }

    public async Task<Guid> AddAsync(CreateUserDto createDto)
    {
        if (await IsEmailExisted(createDto.Email))
        {
            throw new AlreadyExistsException("User with given email already exists.");
        }

        if (createDto.PhoneNumber != null)
        {
            if (await IsPhoneNumberExisted(createDto.PhoneNumber))
            {
                throw new AlreadyExistsException("User with given phone number already exists.");
            }
        }

        var user = new User
        {
            FirstName = createDto.FirstName,
            MiddleName = createDto.MiddleName ?? null,
            LastName = createDto.LastName,
            PhoneNumber = createDto.PhoneNumber ?? null,
            Email = createDto.Email,
            Password = createDto.Password,
            RoleId = createDto.RoleId,
            AccountStatusId = (int)AccountStatusType.NeedsConfirm,
            CreatedAt = DateTime.Now
        };

        await repository.AddAsync(user);
        return user.Id;
    }
}