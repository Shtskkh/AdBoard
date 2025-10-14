using Adboard.AppServices.Contexts.Users.Services;
using Microsoft.AspNetCore.Mvc;

namespace Adboard.Hosts.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class UsersController(IUserService service) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var user = await service.GetByIdAsync(id);
        return Ok(user);
    }
}