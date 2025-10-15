using Adboard.AppServices.Contexts.Categories.Repositories;
using Adboard.Contracts.Categories;
using AutoMapper;

namespace Adboard.AppServices.Contexts.Categories.Services;

public class CategoryService(ICategoryRepository repository, IMapper mapper) : ICategoryService
{
    public async Task<IReadOnlyCollection<CategoryDto>> GetAllAsync()
    {
        var categories = await repository.GetAllAsync();

        var dto = mapper.Map<IReadOnlyCollection<CategoryDto>>(categories);

        return dto;
    }
    
    public async Task<CategoryDto> GetByIdAsync(int id)
    {
        var category = await repository.GetByIdAsync(id);
        
        var dto = mapper.Map<CategoryDto>(category);
        
        return dto;
    }

    public async Task<IReadOnlyCollection<CategoryDto>> GetByTitleAsync(string title)
    {
        var categories = await repository.GetByTitleAsync(title);
        
        var dto = mapper.Map<IReadOnlyCollection<CategoryDto>>(categories);
        
        return dto;
    }
    
    public async Task<int> AddAsync(CreateCategoryDto createDto)
    {
        return await repository.AddAsync(createDto);
    }

    public async Task<CategoryDto> UpdateAsync(UpdateCategoryDto updateDto)
    {
        var updatedCategory = await repository.UpdateAsync(updateDto);

        var dto = mapper.Map<CategoryDto>(updatedCategory);

        return dto;
    }

    public async Task DeleteAsync(int id)
    {
        await repository.GetByIdAsync(id);
        await repository.DeleteAsync(id);
    }
}