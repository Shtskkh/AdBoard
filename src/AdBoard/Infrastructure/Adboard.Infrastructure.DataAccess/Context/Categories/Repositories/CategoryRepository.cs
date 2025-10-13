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
        var categories = await repository.GetAllAsync()
            .Include(c => c.Subcategories)
            .OrderBy(a => a.Id)
            .ToListAsync();
        return categories.AsReadOnly();
    }

    public async Task<Category> GetByIdAsync(int id)
    {
        var category = await repository.GetAllAsync()
            .Where(c => c.Id == id)
            .Include(c => c.Subcategories.OrderBy(a => a.Id))
            .FirstOrDefaultAsync();
        
        return category ?? throw new NotFoundException($"Category with id: {id} not found");
    }

    public async Task<IReadOnlyCollection<Category>> GetByTitleAsync(string title)
    {
        var category = await repository.GetAllAsync()
            .Where(c => EF.Functions.ILike(c.Title, $"%{title}%"))
            .Include(c => c.Subcategories)
            .OrderBy(c => c.Id)
            .ToListAsync();
        
        return category.AsReadOnly() ?? throw new NotFoundException($"Category with title: {title} not found");
    }

    private async Task<bool> IsExistedCategory(string title)
    {
        return await repository.GetAllAsync().AnyAsync(c => c.Title == title);
    }

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

    public async Task DeleteAsync(int id)
    { 
        await repository.DeleteAsync(id);
    }
}