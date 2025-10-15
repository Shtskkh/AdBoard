using Adboard.AppServices.Contexts.Categories.Repositories;
using Adboard.AppServices.Exceptions;
using Adboard.Contracts.Categories;
using Adboard.Domain.Entities;
using Adboard.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Adboard.Infrastructure.DataAccess.Context.Categories.Repositories;

/// <summary>
/// Репозиторий категорий
/// </summary>
/// <param name="repository"></param>
public class CategoryRepository
    (IRepository<Category, int, ApplicationDbContext> repository) : ICategoryRepository
{
    /// <summary>
    /// Получить все категории с подкатегориями
    /// </summary>
    /// <returns>Массив сущностей категорий с подкатегориями</returns>
    public async Task<IReadOnlyCollection<Category>> GetAllAsync()
    {
        var categories = await repository.GetAllAsync()
            .Include(c => c.Subcategories)
            .OrderBy(a => a.Id)
            .ToListAsync();
        return categories.AsReadOnly();
    }

    /// <summary>
    /// Получить категорию с подкатегориями по id
    /// </summary>
    /// <param name="id">Id категории</param>
    /// <returns>Сущность категории с подкатегориями</returns>
    /// <exception cref="NotFoundException">Категория не найдена</exception>
    public async Task<Category> GetByIdAsync(int id)
    {
        var category = await repository.GetAllAsync()
            .Where(c => c.Id == id)
            .Include(c => c.Subcategories.OrderBy(a => a.Id))
            .FirstOrDefaultAsync();
        
        return category ?? throw new NotFoundException($"Category with id: {id} not found");
    }

    /// <summary>
    /// Получить категории по названию с подкатегориями
    /// </summary>
    /// <param name="title"></param>
    /// <returns>Массив сущностей категорий с подкатегориями</returns>
    /// <exception cref="NotFoundException">Категории не найдены</exception>
    public async Task<IReadOnlyCollection<Category>> GetByTitleAsync(string title)
    {
        var category = await repository.GetAllAsync()
            .Where(c => EF.Functions.ILike(c.Title, $"%{title}%"))
            .Include(c => c.Subcategories.OrderBy(a => a.Id))
            .OrderBy(c => c.Id)
            .ToListAsync();
        
        return category.AsReadOnly() ?? throw new NotFoundException($"Category with title: {title} not found");
    }

    private async Task<bool> IsExistedCategory(string title)
    {
        return await repository.GetAllAsync().AnyAsync(c => c.Title == title);
    }

    /// <summary>
    /// Добавить категорию
    /// </summary>
    /// <param name="createDto">Модель создания категории</param>
    /// <returns>Id созданной категории</returns>
    /// <exception cref="AlreadyExistsException">Категория с  таким названием уже существует</exception>
    public async Task<int> AddAsync(CreateCategoryDto createDto)
    {
        
        var categoryExists = await IsExistedCategory(createDto.Title);

        if (categoryExists)
        {
            throw new AlreadyExistsException($"Category with title: {createDto.Title} already exists");
        }
        
        var newCategory = new Category
        {
            Title = createDto.Title
        };
            
        await repository.AddAsync(newCategory);
        return newCategory.Id;
    }

    /// <summary>
    /// Обновить категорию
    /// </summary>
    /// <param name="updateDto">Модель обновления категории</param>
    /// <returns>Сущность обновлённой категории</returns>
    /// <exception cref="AlreadyExistsException">Категория с таким названием уже существует</exception>
    public async Task<Category> UpdateAsync(UpdateCategoryDto updateDto)
    {
        
        var categoryExists = await IsExistedCategory(updateDto.Title);

        if (categoryExists)
        {
            throw new AlreadyExistsException($"Category with title: {updateDto.Title} already exists");
        }
        
        var category = await GetByIdAsync(updateDto.Id);
        category.Title = updateDto.Title;
            
        await repository.UpdateAsync(category);
            
        return category;
    }

    /// <summary>
    /// Удалить категорию
    /// </summary>
    /// <param name="id">Id категории</param>
    public async Task DeleteAsync(int id)
    { 
        await repository.DeleteAsync(id);
    }
}