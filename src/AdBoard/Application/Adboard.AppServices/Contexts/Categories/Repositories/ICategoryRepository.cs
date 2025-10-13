using Adboard.Contracts.Categories;
using Adboard.Domain.Entities;

namespace Adboard.AppServices.Contexts.Categories.Repositories;

public interface ICategoryRepository
{
    Task<IReadOnlyCollection<Category>> GetAllAsync();
    Task<Category> GetByIdAsync(int id);
    Task<IReadOnlyCollection<Category>> GetByTitleAsync(string title);
    Task<int> AddAsync(CreateCategoryDto category);
    Task<Category> UpdateAsync(UpdateCategoryDto category);
    Task DeleteAsync(int id);
}