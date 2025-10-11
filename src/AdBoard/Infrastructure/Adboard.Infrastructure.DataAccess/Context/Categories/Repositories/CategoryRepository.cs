using Adboard.AppServices.Contexts.Categories.Repositories;
using Adboard.AppServices.Exceptions;
using Adboard.Contracts.Categories;
using Adboard.Domain.Entities;
using Adboard.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Adboard.Infrastructure.DataAccess.Context.Categories.Repositories;

public class CategoryRepository
    (IRepository<Category, int, ApplicationDbContext> repository) : ICategoryRepository
{
    public async Task<IReadOnlyCollection<Category>> GetAllAsync()
    {
        var categories = await repository.GetAllAsync().ToListAsync();
        return categories.AsReadOnly();
    }

    public async Task<Category> GetByIdAsync(int id)
    {
        var category = await repository.GetByIdAsync(id);
        return category ?? throw new NotFoundException($"Category with id: {id} not found");
    }

    public async Task<Category> GetByTitleAsync(string title)
    {
        var category = await repository.GetAllAsync()
            .FirstOrDefaultAsync(c => c.Title == title);
        
        return category ?? throw new NotFoundException($"Category with title: {title} not found");
    }

    public async Task<int> AddAsync(CreateCategoryDto createDto)
    {
        try
        {
            await GetByTitleAsync(createDto.Title);
            throw new AlreadyExistsException($"Category with title: {createDto.Title} already exists");
        }
        catch (NotFoundException)
        {
            var newCategory = new Category
            {
                Title = createDto.Title
            };
            
            await repository.AddAsync(newCategory);
            return newCategory.Id;
        }
    }

    public async Task<Category> UpdateAsync(UpdateCategoryDto updateDto)
    {
        try
        {
            await GetByTitleAsync(updateDto.Title);
            throw new AlreadyExistsException($"Category with title: {updateDto.Title} already exists");
        }
        catch (NotFoundException)
        {
            var existedCategory = await GetByIdAsync(updateDto.Id);
            existedCategory.Title = updateDto.Title;
            
            await repository.UpdateAsync(existedCategory);
            
            return existedCategory;
        }
    }

    public async Task DeleteAsync(int id)
    { 
        await repository.DeleteAsync(id);
    }
}