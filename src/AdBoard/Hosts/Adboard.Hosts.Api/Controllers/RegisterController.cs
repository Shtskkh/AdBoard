using Adboard.AppServices.Facades.Register;
using Adboard.Contracts.Errors;
using Adboard.Contracts.Users;
using Microsoft.AspNetCore.Mvc;

namespace Adboard.Hosts.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[ProducesResponseType(typeof(ErrorDto),StatusCodes.Status500InternalServerError)]
public class RegisterController(IRegisterService service) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> RegisterAsync(CreateUserDto createDto)
    {
        var token = await service.RegisterUserAsync(createDto);
        return Ok($"Your verification code: {token}.");
    }

    [HttpPatch]
    public async Task<IActionResult> VerifyUserAsync(string token)
    {
        await service.VerifyUserAsync(token);
        return Ok("Your account has been verified.");
    }
}