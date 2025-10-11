using Adboard.AppServices.Contexts.Categories.Repositories;
using Adboard.AppServices.Exceptions;
using Adboard.Contracts.Categories;
using Adboard.Domain.Entities;

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

        try
        { 
            await repository.GetByTitleAsync(createDto.Title);
            throw new AlreadyExistsException("Category with the given title already exists.");
        }
        
        catch (NotFoundException)
        {
            var category = new Category
            {
                Title = createDto.Title
            };
            
            return await repository.AddAsync(category);
        }
    }

    public async Task<CategoryDto> UpdateAsync(UpdateCategoryDto updateDto)
    {
        if (string.IsNullOrWhiteSpace(updateDto.Title))
        {
            throw new ArgumentException("Title is required.");
        }

        var category = await repository.GetByIdAsync(updateDto.Id);
        
        try
        {
            await repository.GetByTitleAsync(updateDto.Title);
            throw new AlreadyExistsException("Category with the given title already exists.");
        }
        catch (NotFoundException)
        {
            category.Title = updateDto.Title;
        
            var updatedCategory = await repository.UpdateAsync(category);

            var dto = new CategoryDto
            {
                Id = updatedCategory.Id,
                Title = updatedCategory.Title
            };
        
            return dto;
        }
    }

    public async Task DeleteAsync(int id)
    {
        await repository.DeleteAsync(id);
    }
}