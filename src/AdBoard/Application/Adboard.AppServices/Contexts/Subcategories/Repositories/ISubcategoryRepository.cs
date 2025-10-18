using Adboard.Contracts.Subcategories;
using Adboard.Domain.Entities;

namespace Adboard.AppServices.Contexts.Subcategories.Repositories;

public interface ISubcategoryRepository
{
    Task<IReadOnlyCollection<Subcategory>> GetAllAsync();
    Task<Subcategory> GetByIdAsync(int id);
    Task<IReadOnlyCollection<Subcategory>> GetByTitleAsync(string title);
    Task<int> AddAsync(CreateSubcategoryDto createDto);
    Task<Subcategory> UpdateAsync(UpdateSubcategoryDto updateDto);
    Task DeleteAsync(int id);
}