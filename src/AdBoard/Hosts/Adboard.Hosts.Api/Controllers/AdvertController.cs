using Adboard.AppServices.Contexts.Adverts.Services;
using Adboard.Contracts.Adverts;
using Microsoft.AspNetCore.Mvc;

namespace Adboard.Hosts.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AdvertController(IAdvertService service) : ControllerBase
{
    [HttpPost]
    public async Task<Guid> CreateAdvertAsync(CreateAdvertDto createDto)
    {
        return await service.AddAsync(createDto);
    }
}