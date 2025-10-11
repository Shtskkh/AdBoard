using Adboard.Contracts.Subcategories;

namespace Adboard.AppServices.Contexts.Subcategories.Services;

public interface ISubcategoryService
{
    Task<SubcategoryDto> GetByIdAsync(int id);
    Task<IReadOnlyCollection<SubcategoryDto>> GetByTitleAsync(string title);
    Task<int> AddAsync(CreateSubcategoryDto createDto);
    Task<SubcategoryDto> UpdateAsync(UpdateSubcategoryDto updateDto);
    Task DeleteAsync(int id);
}