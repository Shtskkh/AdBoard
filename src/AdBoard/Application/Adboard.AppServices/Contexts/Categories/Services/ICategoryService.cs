using Adboard.Contracts.Categories;

namespace Adboard.AppServices.Contexts.Categories.Services;

public interface ICategoryService
{
    Task<IReadOnlyCollection<CategoryDto>> GetAllAsync();
    Task<CategoryDto> GetByIdAsync(int id);
    Task<IReadOnlyCollection<CategoryDto>> GetByTitleAsync(string title);
    Task<int> AddAsync(CreateCategoryDto category);
    Task<CategoryDto> UpdateAsync(UpdateCategoryDto category);
    Task DeleteAsync(int id);
}