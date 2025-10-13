using Adboard.AppServices.Contexts.Subcategories.Repositories;
using Adboard.AppServices.Exceptions;
using Adboard.Contracts.Subcategories;
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
            .FirstOrDefaultAsync();
        
        return subcategory ?? throw new NotFoundException($"Subcategory with id: {id} not found.");
    }

    public async Task<IReadOnlyCollection<Subcategory>> GetByTitleAsync(string title)
    {
        var subcategories = await repository.GetAllAsync()
            .Where(s => EF.Functions.ILike(s.Title, $"%{title}%"))
            .Include(s => s.Category) 
            .ToListAsync();
        
        return subcategories.AsReadOnly();
    }

    private async Task<bool> IsExistedCategory(int id)
    {
        return await repository.GetAllAsync()
            .Select(s => s.Category).AnyAsync(c => c.Id == id);
    }
    
    private async Task<bool> IsExistedTitleInCategory(string title, int categoryId)
    {
        return await repository.GetAllAsync()
            .AnyAsync(s => s.CategoryId == categoryId && s.Title == title);
    }

    public async Task<int> AddAsync(CreateSubcategoryDto createDto)
    {
        var isExistedCategory = await IsExistedCategory(createDto.CategoryId);

        if (!isExistedCategory)
        {
            throw new ArgumentException($"Category with id: {createDto.CategoryId} not found.");
        }
        
        var existedSubcategory = await IsExistedTitleInCategory(createDto.Title, createDto.CategoryId);

        if (existedSubcategory)
        {
            throw new AlreadyExistsException($"Subcategory with title: {createDto.Title} already exists in category: {createDto.CategoryId}.");
        }
        
        var subcategory = new Subcategory
        {
            Title = createDto.Title,
            CategoryId = createDto.CategoryId
        };
            
        await repository.AddAsync(subcategory);
            
        return subcategory.Id;
    }

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

    public async Task DeleteAsync(int id)
    {
        await repository.DeleteAsync(id);
    }
}