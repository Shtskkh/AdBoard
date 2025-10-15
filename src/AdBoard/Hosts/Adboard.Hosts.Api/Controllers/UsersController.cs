using Adboard.AppServices.Contexts.Users.Services;
using Adboard.Contracts.AccountsStatuses;
using Adboard.Contracts.Errors;
using Adboard.Contracts.Users;
using Microsoft.AspNetCore.Mvc;

namespace Adboard.Hosts.Api.Controllers;

/// <summary>
/// Контроллер пользователей
/// </summary>
/// <param name="service">Сервис пользователей</param>
[ApiController]
[Route("api/v1/[controller]")]
[ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError)]
public class UsersController(IUserService service) : ControllerBase
{
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
        var user = await service.GetByIdAsync(id);
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
        var users = await service.GetByFilterAsync(filter);
        
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
        var updatedUser = await service.UpdateAsync(updateDto);
        return Ok(updatedUser);
    }
}