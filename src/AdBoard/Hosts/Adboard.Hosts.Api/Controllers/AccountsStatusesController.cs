using System.Runtime.InteropServices.JavaScript;
using Adboard.AppServices.Contexts.AccountsStatuses.Services;
using Adboard.Contracts.AccountsStatuses;
using Adboard.Contracts.Errors;
using Microsoft.AspNetCore.Mvc;

namespace Adboard.Hosts.Api.Controllers;

/// <summary>
/// Контроллер статусов аккаунтов пользователей
/// </summary>
/// <param name="service">Сервис статусов аккаунтов</param>
[ApiController]
[Route("api/v1/[controller]")]
[ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError)]
public class AccountsStatusesController(IAccountStatusService service) : ControllerBase
{
    /// <summary>
    /// Получить все статусы аккаунтов
    /// </summary>
    /// <returns>Массив статусов аккаунтов</returns>
    /// <response code="404">Статусы не найдены</response>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<AccountStatusDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllAsync()
    {
        var statuses = await service.GetAllAsync();

        if (statuses.Count == 0)
        {
            return NotFound();
        }
        
        return Ok(statuses);
    }

    /// <summary>
    /// Получить статус аккаунта по id
    /// </summary>
    /// <param name="id">Id статуса аккаунта</param>
    /// <returns>Найденный статус аккаунта</returns>
    /// <response code="404">Статус аккаунта не найден</response>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(AccountStatusDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var status = await service.GetByIdAsync(id);
        return Ok(status);
    }
    
    /// <summary>
    /// Получить статус аккаунта по названию
    /// </summary>
    /// <param name="title">Название статуса аккаунта</param>
    /// <returns>Найденный статус аккаунта</returns>
    /// <response code="400">Неверные параметры</response>
    /// <response code="404">Статус аккаунта не найден</response>
    [HttpGet("{title}")]
    [ProducesResponseType(typeof(AccountStatusDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByTitleAsync(string title)
    {
        var status = await service.GetByTitleAsync(title);
        return Ok(status);
    }
}