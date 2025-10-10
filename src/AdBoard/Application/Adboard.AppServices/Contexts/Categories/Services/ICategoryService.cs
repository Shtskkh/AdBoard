using Adboard.Contracts.Categories;
using Adboard.Domain.Entities;

namespace Adboard.AppServices.Contexts.Categories.Services;

public interface ICategoryService
{
    Task<CategoryDto> GetByIdAsync(int id);
    Task<int> AddAsync(CreateCategoryDto category);
}