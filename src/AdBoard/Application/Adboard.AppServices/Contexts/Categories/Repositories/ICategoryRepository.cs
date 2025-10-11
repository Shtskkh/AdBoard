using Adboard.Domain.Entities;

namespace Adboard.AppServices.Contexts.Categories.Repositories;

public interface ICategoryRepository
{
    Task<IReadOnlyCollection<Category>> GetAllAsync();
    Task<Category> GetByIdAsync(int id);
    Task<Category> GetByTitleAsync(string title);
    Task<int> AddAsync(Category category);
    Task<Category> UpdateAsync(Category category);
    Task DeleteAsync(int id);
}