using Adboard.AppServices.Contexts.Subcategories.Services;
using Adboard.Contracts.Errors;
using Adboard.Contracts.Subcategories;
using Microsoft.AspNetCore.Mvc;

namespace Adboard.Hosts.Api.Controllers;

/// <summary>
/// Контроллер подкатегорий
/// </summary>
/// <param name="service">Сервис подкатегорий</param>
[ApiController]
[Route("api/v1/[controller]")]
[ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError)]
public class SubcategoriesController(ISubcategoryService service) : ControllerBase
{
    
    /// <summary>
    /// Получить подкатегорию по id
    /// </summary>
    /// <param name="id">Id подкатегории</param>
    /// <returns>Найденная подкатегория</returns>
    /// <response code="404">Подкатегория не найдена</response>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(SubcategoryDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var subcategory = await service.GetByIdAsync(id);
        return Ok(subcategory);
    }

    /// <summary>
    /// Получить все подкатегории, частично
    /// или полностью совпадающие с данным названием
    /// </summary>
    /// <param name="title">Название подкатегории</param>
    /// <returns>Массив найденных подкатегорий</returns>
    /// <response code="400">Неверные параметры</response>
    /// <response code="404">Подкатегории с данным названием не найдены</response>
    [HttpGet("{title}")]
    [ProducesResponseType(typeof(IReadOnlyCollection<SubcategoryDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetTitleAsync(string title)
    {
        var subcategories = await service.GetByTitleAsync(title);

        if (subcategories.Count == 0)
        {
            return NotFound();
        }
        
        return Ok(subcategories);
    }

    /// <summary>
    /// Создать подкатегорию
    /// </summary>
    /// <param name="createDto">Модель для создания подкатегории</param>
    /// <returns>Id созданной подкатегории</returns>
    /// <response code="400">Неверные параметры</response>
    /// <response code="409">Подкатегория уже существует</response>
    [HttpPost]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status409Conflict)]
    public async Task<IActionResult> CreateSubcategoryAsync([FromBody] CreateSubcategoryDto createDto)
    {
        var id = await service.AddAsync(createDto);
        return StatusCode(StatusCodes.Status201Created, id);
    }

    /// <summary>
    /// Обновить подкатегорию
    /// </summary>
    /// <param name="updateDto">Модель для обновления подкатегории</param>
    /// <returns>Обновлённая подкатегория</returns>
    /// <response code="400">Неверные параметры</response>
    /// <response code="404">Подкатегория не найдена</response>
    /// <response code="409">Подкатегория уже существует</response>
    [HttpPut]
    [ProducesResponseType(typeof(SubcategoryDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status409Conflict)]
    public async Task<IActionResult> UpdateSubcategoryAsync([FromBody] UpdateSubcategoryDto updateDto)
    {
        var updatedSubcategory = await service.UpdateAsync(updateDto);
        return Ok(updatedSubcategory);
    }
    
    /// <summary>
    /// Удалить подкатегорию
    /// </summary>
    /// <param name="id">Id подкатегории</param>
    /// <returns>Сообщение об успехе</returns>
    /// <response code="404">Подкатегория не найдена</response>
    [HttpDelete("{id:int}")]
    [ProducesResponseType(typeof(string),StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteSubcategoryAsync(int id)
    {
        await service.DeleteAsync(id);
        return Ok("Subcategory deleted");
    }
}