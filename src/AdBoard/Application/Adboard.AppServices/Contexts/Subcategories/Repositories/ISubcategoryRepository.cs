using Adboard.Domain.Entities;

namespace Adboard.AppServices.Contexts.Subcategories;

public interface ISubcategoryRepository
{
    Task<Subcategory> GetByIdAsync(int id);
    Task<Subcategory> GetByCategoryIdAndTitleAsync(int categoryId, string title);
    Task<IReadOnlyCollection<Subcategory>> GetByTitleAsync(string title);
    Task<int> AddAsync(Subcategory subcategory);
    Task<Subcategory> UpdateAsync(Subcategory subcategory);
    Task DeleteAsync(int id);
}