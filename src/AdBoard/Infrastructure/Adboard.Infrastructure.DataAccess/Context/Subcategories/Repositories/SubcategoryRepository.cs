using Adboard.AppServices.Contexts.Subcategories.Repositories;
using Adboard.AppServices.Exceptions;
using Adboard.Contracts.Subcategories;
using Adboard.Domain.Entities;
using Adboard.Infrastructure.DataAccess.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Adboard.Infrastructure.DataAccess.Context.Subcategories.Repositories;

/// <summary>
/// Репозиторий подкатегорий
/// </summary>
/// <param name="repository">Базовый репозиторий подкатегорий</param>
/// <param name="mapper">Автомаппер</param>
public class SubcategoryRepository
    (IRepository<Subcategory, int, ApplicationDbContext> repository, IMapper mapper) : ISubcategoryRepository
{
    /// <summary>
    /// Получить подкатегорию по Id
    /// </summary>
    /// <param name="id">Id подкатегории</param>
    /// <returns>Сущность подкатегории</returns>
    /// <exception cref="NotFoundException">Подкатегория не найдена</exception>
    public async Task<Subcategory> GetByIdAsync(int id)
    {
        var subcategory = await repository.GetAllAsync()
            .Where(s => s.Id == id)
            .Include(s => s.Category)
            .FirstOrDefaultAsync();
        
        return subcategory ?? throw new NotFoundException($"Subcategory with id: {id} not found.");
    }

    /// <summary>
    /// Получить подкатегории по названию
    /// </summary>
    /// <param name="title">Название подкатегории</param>
    /// <returns>Массив подкатегорий, подходящих на название</returns>
    public async Task<IReadOnlyCollection<Subcategory>> GetByTitleAsync(string title)
    {
        var subcategories = await repository.GetAllAsync()
            .Where(s => EF.Functions.ILike(s.Title, $"%{title}%"))
            .Include(s => s.Category)
            .OrderBy(s => s.Id)
            .ToListAsync();
        
        return subcategories.AsReadOnly();
    }
    
    private async Task<bool> IsExistedTitleInCategory(string title, int categoryId)
    {
        return await repository.GetAllAsync()
            .AnyAsync(s => s.CategoryId == categoryId && s.Title == title);
    }

    /// <summary>
    /// Добавить подкатегорию
    /// </summary>
    /// <param name="createDto">Модель создания подкатегории</param>
    /// <returns>Id созданной подкатегории</returns>
    /// <exception cref="AlreadyExistsException">Подкатегория уже существует в категории</exception>
    public async Task<int> AddAsync(CreateSubcategoryDto createDto)
    {
        var existedSubcategory = await IsExistedTitleInCategory(createDto.Title, createDto.CategoryId);

        if (existedSubcategory)
        {
            throw new AlreadyExistsException($"Subcategory with title: {createDto.Title} already exists in category: {createDto.CategoryId}.");
        }
        
        var subcategory = mapper.Map<Subcategory>(createDto);
            
        await repository.AddAsync(subcategory);
            
        return subcategory.Id;
    }

    /// <summary>
    /// Обновить подкатегорию
    /// </summary>
    /// <param name="updateDto">Модель обновления подкатегории</param>
    /// <returns>Обновлённая сущность подкатегории</returns>
    /// <exception cref="AlreadyExistsException">Подкатегория с таким названием уже существует в категории</exception>
    public async Task<Subcategory> UpdateAsync(UpdateSubcategoryDto updateDto)
    { 
        var existedSubcategory = await IsExistedTitleInCategory(updateDto.Title, updateDto.CategoryId);

        if (existedSubcategory)
        {
            throw new AlreadyExistsException($"Subcategory with title: {updateDto.Title} already exists in category: {updateDto.CategoryId}.");
        }
        
        var subcategory = await GetByIdAsync(updateDto.Id);
        
        subcategory.Title = updateDto.Title;
        
        await repository.UpdateAsync(subcategory);
        
        return subcategory;
    }

    /// <summary>
    /// Удалить подкатегорию
    /// </summary>
    /// <param name="id">Id подкатегории</param>
    public async Task DeleteAsync(int id)
    {
        await repository.DeleteAsync(id);
    }
}