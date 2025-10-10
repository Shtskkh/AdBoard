using Adboard.AppServices.Contexts.AccountsStatuses.Services;
using Microsoft.AspNetCore.Mvc;

namespace Adboard.Hosts.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AccountsStatusesController(IAccountStatusService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var statuses = await service.GetAllAsync();

        if (statuses.Count == 0)
        {
            return NoContent();
        }
        
        return Ok(statuses);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var status = await service.GetByIdAsync(id);

        if (status == null)
        {
            return NotFound();
        }
        
        return Ok(status);
    }

    [HttpGet("{title}")]
    public async Task<IActionResult> GetByTitleAsync(string title)
    {
        var status = await service.GetByTitleAsync(title);

        if (status == null)
        {
            return NotFound();
        }
        
        return Ok(status);
    }
}