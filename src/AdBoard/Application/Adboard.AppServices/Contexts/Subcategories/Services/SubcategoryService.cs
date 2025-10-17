using Adboard.AppServices.Contexts.Categories.Repositories;
using Adboard.AppServices.Contexts.Subcategories.Repositories;
using Adboard.AppServices.Exceptions;
using Adboard.Contracts.Subcategories;

namespace Adboard.AppServices.Contexts.Subcategories.Services;

public class SubcategoryService
    (ISubcategoryRepository subcategoryRepository, ICategoryRepository categoryRepository) : ISubcategoryService
{
    public async Task<SubcategoryDto> GetByIdAsync(int id)
    {
        var subcategory = await subcategoryRepository.GetByIdAsync(id);
        
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
        var subcategories = await subcategoryRepository.GetByTitleAsync(title);
        var dtos = subcategories.Select(s => new SubcategoryDto
        {
            CategoryId = s.CategoryId,
            CategoryTitle = s.Category.Title,
            Id = s.Id,
            Title = s.Title
        }).ToList();
        
        return dtos.AsReadOnly();
    }

    private async Task<bool> IsExistedCategory(int id)
    {
        try
        {
            await categoryRepository.GetByIdAsync(id);
            return true;
        }
        catch (NotFoundException)
        {
            return false;
        }
    }

    public async Task<int> AddAsync(CreateSubcategoryDto createDto)
    {
        var categoryExists = await IsExistedCategory(createDto.CategoryId);

        if (!categoryExists)
        {
            throw new ArgumentException("Category not found.");
        }
        
        if (string.IsNullOrWhiteSpace(createDto.Title))
        {
            throw new ArgumentException("Title is required.");
        }
        
        return await subcategoryRepository.AddAsync(createDto);
    }
    
    public async Task<SubcategoryDto> UpdateAsync(UpdateSubcategoryDto updateDto)
    {
        if (string.IsNullOrWhiteSpace(updateDto.Title))
        {
            throw new ArgumentException("Title is required.");
        }
        
        var subcategory = await subcategoryRepository.UpdateAsync(updateDto);

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
        await subcategoryRepository.GetByIdAsync(id);
        await subcategoryRepository.DeleteAsync(id);
    }
}