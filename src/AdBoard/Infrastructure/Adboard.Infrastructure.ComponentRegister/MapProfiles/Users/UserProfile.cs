using Adboard.Contracts.Users;
using Adboard.Domain.Entities;
using AutoMapper;

namespace Adboard.Infrastructure.ComponentRegister.MapProfiles.Users;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UpdateUserDto, User>(MemberList.None)
            .ForMember(dest => dest.RoleId, opt => opt.PreCondition(src => src.RoleId.HasValue))
            .ForMember(dest => dest.AccountStatusId, opt => opt.PreCondition(src => src.AccountStatusId.HasValue))
            .ForAllMembers(s =>
                s.Condition((src, dest, srcMember) => srcMember != null));

        CreateMap<User, UserDto>(MemberList.None);

    }
}