using Adboard.Contracts.Subcategories;
using Adboard.Domain.Entities;
using AutoMapper;

namespace Adboard.Infrastructure.ComponentRegister.MapProfiles;

public class SubcategoryProfile : Profile
{
    public SubcategoryProfile()
    {
        CreateMap<CreateSubcategoryDto, Subcategory>(MemberList.None);
        CreateMap<Subcategory, ShortSubcategoryDto>(MemberList.None);
    }
}