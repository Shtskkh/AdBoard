using Adboard.AppServices.Contexts.Categories.Services;
using Adboard.Contracts.Categories;
using Adboard.Contracts.Errors;
using Adboard.Contracts.Subcategories;
using Microsoft.AspNetCore.Mvc;

namespace Adboard.Hosts.Api.Controllers;

/// <summary>
/// Контроллер категорий
/// </summary>
/// <param name="service">Сервис категорий</param>
[ApiController]
[Route("api/v1/[controller]")]
[ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError)]
public class CategoriesController(ICategoryService service) : ControllerBase
{
    /// <summary>
    /// Получить категорию по id
    /// </summary>
    /// <param name="id">Id категории</param>
    /// <returns>Найденная категория</returns>
    /// <response code="404">Категория не найдена</response>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(SubcategoryDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var category = await service.GetByIdAsync(id);
        return Ok(category);
    }
    
    /// <summary>
    /// Создать категорию
    /// </summary>
    /// <param name="createDto">Модель создания категории</param>
    /// <returns>Id созданной категории</returns>
    /// <response code="400">Неверные параметры</response>
    /// <response code="409">Категория уже существует</response>
    [HttpPost]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status409Conflict)]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDto createDto)
    {
        var id = await service.AddAsync(createDto);
        return Ok(id);
    }

    /// <summary>
    /// Обновить категорию
    /// </summary>
    /// <param name="updateDto">Модель обновления категории</param>
    /// <returns>Обновлённая категория</returns>
    /// <response code="400">Неверные параметры</response>
    /// <response code="404">Категория не найдена</response>
    /// <response code="409">Категория уже существует</response>
    [HttpPut]
    [ProducesResponseType(typeof(SubcategoryDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status409Conflict)]
    public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryDto updateDto)
    {
        var updatedCategory = await service.UpdateAsync(updateDto);
        return Ok(updatedCategory);
    }

    /// <summary>
    /// Удалить категорию
    /// </summary>
    /// <param name="id">Id категории для удаления</param>
    /// <returns>Сообщение об успешном удалении</returns>
    /// <response code="404">Категория не найдена</response>
    [HttpDelete("{id:int}")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await service.DeleteAsync(id);
        return Ok("Category deleted");
    }
}