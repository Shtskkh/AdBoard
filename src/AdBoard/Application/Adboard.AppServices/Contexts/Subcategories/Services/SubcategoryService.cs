using Adboard.AppServices.Contexts.Categories.Repositories;
using Adboard.AppServices.Exceptions;
using Adboard.Contracts.Subcategories;
using Adboard.Domain.Entities;

namespace Adboard.AppServices.Contexts.Subcategories.Services;

public class SubcategoryService
    (ISubcategoryRepository subcategoryRepository, ICategoryRepository categoryRepository) : ISubcategoryService
{
    public async Task<SubcategoryDto> GetByIdAsync(int id)
    {
        var subcategory = await subcategoryRepository.GetByIdAsync(id);
        
        var dto = new SubcategoryDto
        {
            CategoryId = subcategory.CategoryId,
            CategoryTitle = subcategory.Category.Title,
            Id = subcategory.Id,
            Title = subcategory.Title
        };

        return dto;
    }

    public async Task<IReadOnlyCollection<SubcategoryDto>> GetByTitleAsync(string title)
    {
        var subcategories = await subcategoryRepository.GetByTitleAsync(title);
        var dtos = subcategories.Select(s => new SubcategoryDto
        {
            CategoryId = s.CategoryId,
            CategoryTitle = s.Category.Title,
            Id = s.Id,
            Title = s.Title
        }).ToList();
        
        return dtos.AsReadOnly();
    }

    public async Task<int> AddAsync(CreateSubcategoryDto createDto)
    {
        if (string.IsNullOrWhiteSpace(createDto.Title))
        {
            throw new ArgumentException("Title is required.");
        }

        var category = await categoryRepository.GetByIdAsync(createDto.CategoryId);

        try
        {
            await subcategoryRepository.GetByCategoryIdAndTitleAsync(createDto.CategoryId, createDto.Title);
            throw new AlreadyExistsException($"Subcategory with title: {createDto.Title} in category: {category.Title} already exists.");
        }
        catch (NotFoundException)
        {
            var subcategory = new Subcategory
            {
                Title = createDto.Title,
                CategoryId = createDto.CategoryId
            };
         
            return await subcategoryRepository.AddAsync(subcategory);
        }
    }
    
    public async Task<SubcategoryDto> UpdateAsync(UpdateSubcategoryDto updateDto)
    {
        if (string.IsNullOrWhiteSpace(updateDto.Title))
        {
            throw new ArgumentException("Title is required.");
        }
        
        var subcategory = await subcategoryRepository.GetByIdAsync(updateDto.Id);

        try
        {
            await subcategoryRepository.GetByCategoryIdAndTitleAsync(updateDto.CategoryId, updateDto.Title);
            throw new AlreadyExistsException($"Subcategory with title '{updateDto.Title}' already exists in category with title: {subcategory.Category.Title}.");
        }
        catch (NotFoundException)
        {
            subcategory.Title = updateDto.Title;
            await subcategoryRepository.UpdateAsync(subcategory);

            var dto = new SubcategoryDto
            {
                CategoryId = subcategory.CategoryId,
                CategoryTitle = subcategory.Category.Title,
                Id = subcategory.Id,
                Title = subcategory.Title
            };

            return dto;
        }
    }

    public async Task DeleteAsync(int id)
    {
        await subcategoryRepository.GetByIdAsync(id);
        await subcategoryRepository.DeleteAsync(id);
    }
}