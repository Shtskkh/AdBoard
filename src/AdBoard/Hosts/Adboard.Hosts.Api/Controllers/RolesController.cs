using Adboard.AppServices.Contexts.Roles.Services;
using Microsoft.AspNetCore.Mvc;

namespace Adboard.Hosts.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class RolesController(IRoleService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var roles = await service.GetAllAsync();

        if (roles.Count == 0)
        {
            return NotFound();
        }
        
        return Ok(roles);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var role = await service.GetByIdAsync(id);
        
        if (role == null)
        {
            return NotFound();
        }
        
        return Ok(role);
    }

    [HttpGet("{title}")]
    public async Task<IActionResult> GetByTitleAsync(string title)
    {
        var role = await service.GetByTitleAsync(title);

        if (role == null)
        {
            return NotFound();
        }
        
        return Ok(role);
    }
}