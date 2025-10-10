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
            Title = category.Title,
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
            var existingCategory = await repository.GetByTitleAsync(createDto.Title);
            throw new AlreadyExistsException("Category with the given title already exists.");
        }
        
        catch (NotFoundException)
        {
            var category = new Category
            {
                Title = createDto.Title,
            };
            
            return await repository.AddAsync(category);
        }
    }
}