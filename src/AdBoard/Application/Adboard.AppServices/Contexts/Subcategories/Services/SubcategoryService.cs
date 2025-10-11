using Adboard.AppServices.Contexts.Categories.Repositories;
using Adboard.AppServices.Contexts.Subcategories.Repositories;
using Adboard.AppServices.Exceptions;
using Adboard.Contracts.Subcategories;

namespace Adboard.AppServices.Contexts.Subcategories.Services;

public class SubcategoryService
    (ISubcategoryRepository repository) : ISubcategoryService
{
    public async Task<SubcategoryDto> GetByIdAsync(int id)
    {
        var subcategory = await repository.GetByIdAsync(id);
        
        var dto = new SubcategoryDto
        {
            CategoryId = subcategory.CategoryId,
            CategoryTitle = subcategory.Category.Title,
            Id = subcategory.Id,
            Title = subcategory.Title
        };

        return dto;
    }

    public async Task<IReadOnlyCollection<SubcategoryDto>> GetByTitleAsync(string title)
    {
        var subcategories = await repository.GetByTitleAsync(title);
        var dtos = subcategories.Select(s => new SubcategoryDto
        {
            CategoryId = s.CategoryId,
            CategoryTitle = s.Category.Title,
            Id = s.Id,
            Title = s.Title
        }).ToList();
        
        return dtos.AsReadOnly();
    }

    public async Task<int> AddAsync(CreateSubcategoryDto createDto)
    {
        if (string.IsNullOrWhiteSpace(createDto.Title))
        {
            throw new ArgumentException("Title is required.");
        }
        
        return await repository.AddAsync(createDto);
    }
    
    public async Task<SubcategoryDto> UpdateAsync(UpdateSubcategoryDto updateDto)
    {
        if (string.IsNullOrWhiteSpace(updateDto.Title))
        {
            throw new ArgumentException("Title is required.");
        }
        
        var subcategory = await repository.UpdateAsync(updateDto);

        var dto = new SubcategoryDto
        {
            CategoryId = subcategory.CategoryId,
            CategoryTitle = subcategory.Category.Title,
            Id = subcategory.Id,
            Title = subcategory.Title
        };
        
        return dto;
    }

    public async Task DeleteAsync(int id)
    {
        await repository.GetByIdAsync(id);
        await repository.DeleteAsync(id);
    }
}