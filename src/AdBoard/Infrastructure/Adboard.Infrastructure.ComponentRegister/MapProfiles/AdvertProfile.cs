using Adboard.Contracts.Adverts;
using Adboard.Domain.Entities;
using AutoMapper;

namespace Adboard.Infrastructure.ComponentRegister.MapProfiles;

public class AdvertProfile : Profile
{
    public AdvertProfile()
    {
        CreateMap<Advert, AdvertDto>(MemberList.None);
        
        CreateMap<CreateAdvertDto, Advert>(MemberList.None)
            .ForMember(dest => dest.CreatedAt, 
                opt => 
                    opt.MapFrom(src => DateTime.Now.ToUniversalTime()));
    }
}