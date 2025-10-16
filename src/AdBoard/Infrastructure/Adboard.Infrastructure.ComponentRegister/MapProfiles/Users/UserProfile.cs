using Adboard.Contracts.Roles;
using Adboard.Contracts.Users;
using Adboard.Domain.Entities;
using Adboard.Domain.Enums;
using AutoMapper;

namespace Adboard.Infrastructure.ComponentRegister.MapProfiles.Users;

public class UserProfile : Profile
{
    public UserProfile()
    {

        CreateMap<CreateUserDto, User>(MemberList.None)
            .ForMember(dest => dest.AccountStatusId,
                opt => opt.MapFrom(status => (int)AccountStatusType.NeedsConfirm))
            .ForMember(dest => dest.CreatedAt,
                opt => opt.MapFrom(src => DateTime.UtcNow.ToUniversalTime()));
        
        CreateMap<UpdateUserDto, User>(MemberList.None)
            .ForMember(dest => dest.RoleId, 
                opt => opt.PreCondition(src => src.RoleId.HasValue))
            .ForMember(dest => dest.AccountStatusId, 
                opt => opt.PreCondition(src => src.AccountStatusId.HasValue))
            .ForAllMembers(s =>
                s.Condition((src, dest, srcMember) => srcMember != null));

        CreateMap<User, UserDto>(MemberList.None)
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.Title))
            .ForMember(dest => dest.AccountStatus, opt => opt.MapFrom(src => src.AccountStatus.Title));

        CreateMap<User, UserAuthInfoDto>(MemberList.None);
    }
}