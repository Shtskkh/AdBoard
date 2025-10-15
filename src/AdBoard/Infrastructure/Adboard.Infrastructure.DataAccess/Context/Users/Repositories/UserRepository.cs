using Adboard.AppServices.Contexts.Users.Repositories;
using Adboard.AppServices.Contexts.Users.Specifications;
using Adboard.AppServices.Exceptions;
using Adboard.Contracts.Users;
using Adboard.Domain.Entities;
using Adboard.Infrastructure.DataAccess.Repositories;
using Ardalis.Specification.EntityFrameworkCore;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Adboard.Infrastructure.DataAccess.Context.Users.Repositories;

/// <summary>
/// Репозиторий пользователей
/// </summary>
/// <param name="repository">Базовый репозиторий для пользователей</param>
/// <param name="mapper">Автомаппер</param>
public class UserRepository
    (IRepository<User, Guid, ApplicationDbContext> repository, IMapper mapper) : IUserRepository
{
    /// <summary>
    /// Получить всех пользователей, удовлетворяющих фильтру
    /// </summary>
    /// <param name="specification">Спецификация для фильтра</param>
    /// <returns>Массив сущностей пользователей, удовлетворяющих фильтру</returns>
    public async Task<IReadOnlyCollection<User>> GetByFilterAsync(UserFilterSpecification specification)
    {
        var users = await repository.GetAllAsync()
            .WithSpecification(specification)
            .ToListAsync();
        return users.AsReadOnly();
    }

    /// <summary>
    /// Получить пользователя по id
    /// </summary>
    /// <param name="id">Id пользователя</param>
    /// <returns>Сущность пользователя</returns>
    /// <exception cref="NotFoundException">Пользователь не найден</exception>
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
    
    /// <summary>
    /// Создать пользователя
    /// </summary>
    /// <param name="createDto">Модель создания пользователя</param>
    /// <returns>Id созданного пользователя</returns>
    /// <exception cref="AlreadyExistsException">
    ///     Пользователь с такой почтой или таким номером телефона уже существует в БД
    /// </exception>
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
        
        var user = mapper.Map<CreateUserDto, User>(createDto);

        await repository.AddAsync(user);
        return user.Id;
    }

    /// <summary>
    /// Обновить пользователя
    /// </summary>
    /// <param name="updateDto">Модель обновления пользователя</param>
    /// <returns>Обновлённая сущность пользователя</returns>
    /// <exception cref="NotFoundException">Пользователь для обновления не найден</exception>
    public async Task<User> UpdateAsync(UpdateUserDto updateDto)
    {
        var user = await GetByIdAsync(updateDto.Id);

        if (user == null)
        {
            throw new NotFoundException("User with the given id does not exist.");
        }
        
        mapper.Map(updateDto, user);
        
        await repository.UpdateAsync(user);
        return user;
    }
}