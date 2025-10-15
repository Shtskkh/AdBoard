using Adboard.Contracts.Categories;
using Adboard.Contracts.Subcategories;
using Adboard.Domain.Entities;
using AutoMapper;

namespace Adboard.Infrastructure.ComponentRegister.MapProfiles.Users;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<Category, CategoryDto>(MemberList.None);
        CreateMap<Subcategory, ShortSubcategoryDto>(MemberList.None);
        CreateMap<CreateCategoryDto, Category>(MemberList.None);
        CreateMap<UpdateCategoryDto, Category>(MemberList.None);
    }
}