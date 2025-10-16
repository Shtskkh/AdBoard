using Adboard.AppServices.Contexts.Users.Services;
using Adboard.AppServices.Facades.Users;
using Adboard.Contracts.AccountsStatuses;
using Adboard.Contracts.Errors;
using Adboard.Contracts.Users;
using Microsoft.AspNetCore.Mvc;

namespace Adboard.Hosts.Api.Controllers;

/// <summary>
/// Контроллер пользователей
/// </summary>
/// <param name="facade">Сервис пользователей</param>
[ApiController]
[Route("api/v1/[controller]")]
[ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError)]
public class UsersController(IUserFacade facade) : ControllerBase
{
    
    /// <summary>
    /// Зарегистрировать пользователя
    /// </summary>
    /// <param name="createDto">Модель создания пользователя</param>
    /// <returns>Строка с кодом подтверждения</returns>
    /// <response code="400">Неверные параметры</response>
    /// <response code="409">Пользователь с таким email или номером телефона уже существует</response>
    [HttpPost]
    [ProducesResponseType(typeof(string), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status409Conflict)]
    public async Task<IActionResult> RegisterAsync(CreateUserDto createDto)
    {
        var token = await facade.RegisterUserAsync(createDto);
        return Ok(token);
    }
    
    /// <summary>
    /// Верифицировать пользователя
    /// </summary>
    /// <param name="token">Токен подтверждения</param>
    /// <returns>Сообщение об успешной верификации</returns>
    /// <response code="404">Пользователь с таким Id не найден</response>
    [HttpPatch("Verify")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> VerifyUserAsync(string token)
    {
        await facade.VerifyUserAsync(token);
        return Ok("Your account has been verified.");
    }
    
    /// <summary>
    /// Получить пользователя по id
    /// </summary>
    /// <param name="id">Id пользователя</param>
    /// <returns>Модель пользователя</returns>
    /// <response code="404">Пользователь не найден</response>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(AccountStatusDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var user = await facade.GetByIdAsync(id);
        return Ok(user);
    }

    /// <summary>
    /// Получить пользователей по фильтру
    /// </summary>
    /// <param name="filter">Модель фильтра</param>
    /// <returns>Найденные пользователи</returns>
    /// <response code="404">Пользователи не найдены</response>
    [HttpGet("by-filter")]
    [ProducesResponseType(typeof(AccountStatusDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByFilterAsync([FromQuery] UserFilterDto filter)
    {
        var users = await facade.GetByFilterAsync(filter);
        
        if (users.Count == 0)
        {
            return NotFound();
        }
        
        return Ok(users);
    }

    /// <summary>
    /// Обновить пользователя
    /// </summary>
    /// <param name="updateDto">Модель обновления пользователя</param>
    /// <returns>Модель обновлённого пользователя</returns>
    /// <response code="404">Пользователь для обновления не найден</response>
    [HttpPut]
    [ProducesResponseType(typeof(AccountStatusDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateAsync(UpdateUserDto updateDto)
    {
        var updatedUser = await facade.UpdateAsync(updateDto);
        return Ok(updatedUser);
    }

    [HttpPatch("Password")]
    public async Task<IActionResult> UpdatePasswordAsync(UpdatePasswordDto updatePasswordDto)
    {
        await facade.UpdatePasswordAsync(updatePasswordDto);
        return Ok("Your password has been updated.");
    }
}