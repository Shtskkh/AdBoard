using Adboard.AppServices.Contexts.Categories.Services;
using Adboard.Contracts.Categories;
using Microsoft.AspNetCore.Mvc;

namespace Adboard.Hosts.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class CategoriesController(ICategoryService service) : ControllerBase
{
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var category = await service.GetByIdAsync(id);
        return Ok(category);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDto category)
    {
        var id = await service.AddAsync(category);
        return Ok(id);
    }
}