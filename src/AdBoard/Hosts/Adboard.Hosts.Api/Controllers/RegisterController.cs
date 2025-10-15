using Adboard.AppServices.Facades.Register;
using Adboard.Contracts.Errors;
using Adboard.Contracts.Users;
using Microsoft.AspNetCore.Mvc;

namespace Adboard.Hosts.Api.Controllers;

/// <summary>
/// Контроллер регистрации
/// </summary>
/// <param name="service">Фасад регистрации</param>
[ApiController]
[Route("api/v1/[controller]")]
[ProducesResponseType(typeof(ErrorDto),StatusCodes.Status500InternalServerError)]
public class RegisterController(IRegisterService service) : ControllerBase
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
        var token = await service.RegisterUserAsync(createDto);
        return Ok(token);
    }
    
    /// <summary>
    /// Верифицировать пользователя
    /// </summary>
    /// <param name="token">Токен подтверждения</param>
    /// <returns>Сообщение об успешной верификации</returns>
    /// <response code="404">Пользователь с таким Id не найден</response>
    [HttpPatch("{token:minlength(36)}")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> VerifyUserAsync(string token)
    {
        await service.VerifyUserAsync(token);
        return Ok("Your account has been verified.");
    }
}