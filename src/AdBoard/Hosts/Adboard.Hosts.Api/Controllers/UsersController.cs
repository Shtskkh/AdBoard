using Adboard.AppServices.Contexts.Users.Services;
using Adboard.Contracts.Users;
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

    [HttpGet("by-filter")]
    public async Task<IActionResult> GetByFilterAsync([FromQuery] UserFilterDto filter)
    {
        var users = await service.GetByFilterAsync(filter);
        
        if (users.Count == 0)
        {
            return NotFound();
        }
        
        return Ok(users);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(UpdateUserDto updateDto)
    {
        var updatedUser = await service.UpdateAsync(updateDto);
        return Ok(updatedUser);
    }
}