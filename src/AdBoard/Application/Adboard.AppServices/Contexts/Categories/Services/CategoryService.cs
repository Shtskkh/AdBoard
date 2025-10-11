using Adboard.AppServices.Contexts.Categories.Repositories;
using Adboard.Contracts.Categories;

namespace Adboard.AppServices.Contexts.Categories.Services;

public class CategoryService(ICategoryRepository repository) : ICategoryService
{
    public async Task<CategoryDto> GetByIdAsync(int id)
    {
        var category = await repository.GetByIdAsync(id);

        var dto = new CategoryDto
        {
            Id = category.Id,
            Title = category.Title
        };
        
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