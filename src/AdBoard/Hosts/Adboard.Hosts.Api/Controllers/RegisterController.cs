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
    public async Task<string> RegisterAsync(CreateUserDto createDto)
    {
        var code = await service.RegisterUser(createDto);
        return code;
    }
}