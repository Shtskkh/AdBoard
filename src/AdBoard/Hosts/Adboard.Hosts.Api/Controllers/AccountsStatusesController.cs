using System.Net;
using Adboard.AppServices.Contexts.AccountsStatuses.Services;
using Adboard.Contracts.AccountsStatuses;
using Microsoft.AspNetCore.Http.HttpResults;
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

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody]CreateAccountStatusDto dto)
    {
        var id = await service.AddAsync(dto);
        return StatusCode((int)HttpStatusCode.Created, id);
    }
}