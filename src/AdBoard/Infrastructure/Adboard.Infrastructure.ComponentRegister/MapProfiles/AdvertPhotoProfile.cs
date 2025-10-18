using Adboard.Contracts.AdvertsPhotos;
using Adboard.Domain.Entities;
using AutoMapper;

namespace Adboard.Infrastructure.ComponentRegister.MapProfiles;

public class AdvertPhotoProfile : Profile
{
    public AdvertPhotoProfile()
    {
        CreateMap<CreateAdvertPhotoDto, AdvertPhoto>(MemberList.None);
    }
}