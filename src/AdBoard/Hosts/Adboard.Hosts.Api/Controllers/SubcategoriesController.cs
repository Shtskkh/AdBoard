using Adboard.AppServices.Contexts.Categories.Services;
using Adboard.AppServices.Contexts.Subcategories.Services;
using Adboard.Contracts.Subcategories;
using Microsoft.AspNetCore.Mvc;

namespace Adboard.Hosts.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class SubcategoriesController(ISubcategoryService service) : ControllerBase
{
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var subcategory = await service.GetByIdAsync(id);
        return Ok(subcategory);
    }

    [HttpGet("{title}")]
    public async Task<IActionResult> GetTitleAsync(string title)
    {
        var subcategories = await service.GetByTitleAsync(title);

        if (subcategories.Count == 0)
        {
            return NoContent();
        }
        
        return Ok(subcategories);
    }

    [HttpPost]
    public async Task<IActionResult> CreateSubcategoryAsync([FromBody] CreateSubcategoryDto createDto)
    {
        var id = await service.AddAsync(createDto);
        return Ok(id);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateSubcategoryAsync([FromBody] UpdateSubcategoryDto updateDto)
    {
        var updatedSubcategory = await service.UpdateAsync(updateDto);
        return Ok(updatedSubcategory);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteSubcategoryAsync(int id)
    {
        await service.DeleteAsync(id);
        return Ok();
    }
}