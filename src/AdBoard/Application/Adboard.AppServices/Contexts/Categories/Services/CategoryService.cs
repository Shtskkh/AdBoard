using Adboard.AppServices.Contexts.Categories.Repositories;
using Adboard.Contracts.Categories;
using Adboard.Contracts.Subcategories;

namespace Adboard.AppServices.Contexts.Categories.Services;

public class CategoryService(ICategoryRepository repository) : ICategoryService
{
    public async Task<IReadOnlyCollection<CategoryDto>> GetAllAsync()
    {
        var categories = await repository.GetAllAsync();

        var dto = categories.Select(c => new CategoryDto
        {
            Id = c.Id,
            Title = c.Title,
            Subcategories = c.Subcategories.Select(s => new ShortSubcategoryDto
            {
                Id = s.Id,
                Title = s.Title
            }).ToList().AsReadOnly()
        }).ToList();
        
        return dto.AsReadOnly();
    }
    
    public async Task<CategoryDto> GetByIdAsync(int id)
    {
        var category = await repository.GetByIdAsync(id);

        var dto = new CategoryDto
        {
            Id = category.Id,
            Title = category.Title,
            Subcategories = category.Subcategories.Select(s => new ShortSubcategoryDto
            {
                Id = s.Id,
                Title = s.Title
            }).ToList().AsReadOnly()
        };
        
        return dto;
    }

    public async Task<IReadOnlyCollection<CategoryDto>> GetByTitleAsync(string title)
    {
        var categories = await repository.GetByTitleAsync(title);
        
        var dto = categories.Select(c => new CategoryDto
        {
            Id = c.Id,
            Title = c.Title,
            Subcategories = c.Subcategories.Select(s => new ShortSubcategoryDto
            {
                Id = s.Id,
                Title = s.Title
            }).ToList().AsReadOnly()
        }).ToList().AsReadOnly();
        
        return dto;
    }
    
    public async Task<int> AddAsync(CreateCategoryDto createDto)
    {
        if (string.IsNullOrWhiteSpace(createDto.Title))
        {
            throw new ArgumentException("Title is required.");
        }
        
        return await repository.AddAsync(createDto);
    }

    public async Task<CategoryDto> UpdateAsync(UpdateCategoryDto updateDto)
    {
        if (string.IsNullOrWhiteSpace(updateDto.Title))
        {
            throw new ArgumentException("Title is required.");
        }

        var updatedCategory = await repository.UpdateAsync(updateDto);

        var dto = new CategoryDto
        {
            Id = updatedCategory.Id,
            Title = updatedCategory.Title
        };

        return dto;
    }

    public async Task DeleteAsync(int id)
    {
        await repository.GetByIdAsync(id);
        await repository.DeleteAsync(id);
    }
}