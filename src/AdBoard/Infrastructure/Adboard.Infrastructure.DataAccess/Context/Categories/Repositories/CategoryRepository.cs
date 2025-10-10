using Adboard.AppServices.Contexts.Categories.Repositories;
using Adboard.AppServices.Exceptions;
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

    public async Task<int> AddAsync(Category category)
    {
        await repository.AddAsync(category);
        return category.Id;
    }

    public async Task UpdateAsync(Category category)
    {
        await repository.UpdateAsync(category);
    }

    public async Task DeleteAsync(int id)
    {
        var category = await repository.GetByIdAsync(id);

        if (category == null)
        {
            throw new NotFoundException($"Category with id: {id} not found");
        }
        
        await repository.DeleteAsync(id);
    }
}