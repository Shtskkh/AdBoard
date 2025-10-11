using Adboard.AppServices.Contexts.Roles.Services;
using Adboard.Contracts.Errors;
using Adboard.Contracts.Roles;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Adboard.Hosts.Api.Controllers;

/// <summary>
/// Контроллер ролей пользователей
/// </summary>
/// <param name="service">Сервис ролей</param>
[Route("api/v1/[controller]")]
[ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError)]
public class RolesController(IRoleService service) : ControllerBase
{
    /// <summary>
    /// Получить все роли
    /// </summary>
    /// <returns>Массив ролей</returns>
    /// <response code="404">Роли не найдены</response>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<RoleDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllAsync()
    {
        var roles = await service.GetAllAsync();

        if (roles.Count == 0)
        {
            return NotFound();
        }
        
        return Ok(roles);
    }

    /// <summary>
    /// Получить роль по id
    /// </summary>
    /// <param name="id">Id роли</param>
    /// <returns>Модель роли</returns>
    /// <response code="404">Роль не найдена</response>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(RoleDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var role = await service.GetByIdAsync(id);
        return Ok(role);
    }

    /// <summary>
    /// Получить роль по названию
    /// </summary>
    /// <param name="title">Название роли</param>
    /// <returns>Модель роли</returns>
    /// <response code="400">Неверные параметры</response>
    /// <response code="404">Роль не найдена</response>
    [HttpGet("{title}")]
    [ProducesResponseType(typeof(RoleDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByTitleAsync(string title)
    {
        var role = await service.GetByTitleAsync(title);
        return Ok(role);
    }
}