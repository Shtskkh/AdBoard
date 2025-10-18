using Adboard.AppServices.Contexts.Adverts.Services;
using Adboard.Contracts.Adverts;
using Microsoft.AspNetCore.Mvc;

namespace Adboard.Hosts.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AdvertController(IAdvertService service) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var advert = await service.GetByIdAsync(id);
        
        return Ok(advert);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateAdvertAsync(CreateAdvertDto createDto)
    {
        var guid = await service.AddAsync(createDto);
        
        return Ok(guid);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        await service.DeleteAsync(id);
        return Ok("Advert deleted.");
    }
}