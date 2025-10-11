using Adboard.AppServices.Contexts.Subcategories;
using Adboard.AppServices.Exceptions;
using Adboard.Domain.Entities;
using Adboard.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Adboard.Infrastructure.DataAccess.Context.Subcategories.Repositories;

public class SubcategoryRepository
    (IRepository<Subcategory, int, ApplicationDbContext> repository) : ISubcategoryRepository
{
    public async Task<Subcategory> GetByIdAsync(int id)
    {
        var subcategory = await repository.GetAllAsync()
            .Where(s => s.Id == id)
            .Include(s => s.Category)
            .Select(s => new Subcategory
            {
                Id = s.Id,
                Title = s.Title,
                CategoryId = s.CategoryId,
                Category = s.Category
            })
            .FirstOrDefaultAsync();
        
        return subcategory ?? throw new NotFoundException($"Subcategory with id: {id} not found.");
    }

    public async Task<Subcategory> GetByCategoryIdAndTitleAsync(int categoryId, string title)
    {
        var subcategory = await repository.GetAllAsync()
            .Where(s => s.CategoryId == categoryId && s.Title == title)
            .Include(s => s.Category)
            .Select(s => new Subcategory
            {
                Id = s.Id,
                Title = s.Title,
                CategoryId = s.CategoryId,
                Category = s.Category
            }).FirstOrDefaultAsync();
        
        return subcategory ?? throw new NotFoundException($"Subcategory with id: {categoryId} and title: {title} not found.");
    }

    public async Task<IReadOnlyCollection<Subcategory>> GetByTitleAsync(string title)
    {
        var subcategories = await repository.GetAllAsync()
            .Where(s => EF.Functions.Like(s.Title, $"%{title}%"))
            .Include(s => s.Category)
            .Select(s => new Subcategory
            {
                Id = s.Id,
                Title = s.Title,
                CategoryId = s.CategoryId,
                Category = s.Category
            }).ToListAsync();
        
        return subcategories.AsReadOnly();
    }

    public async Task<int> AddAsync(Subcategory subcategory)
    {
        await repository.AddAsync(subcategory);
        return subcategory.Id;
    }

    public async Task<Subcategory> UpdateAsync(Subcategory subcategory)
    {
        await repository.UpdateAsync(subcategory);
        return subcategory;
    }

    public async Task DeleteAsync(int id)
    {
        await repository.DeleteAsync(id);
    }
}