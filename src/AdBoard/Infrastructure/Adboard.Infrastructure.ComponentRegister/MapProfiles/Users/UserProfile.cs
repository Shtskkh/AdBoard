using Adboard.Contracts.Users;
using Adboard.Domain.Entities;
using AutoMapper;

namespace Adboard.Infrastructure.ComponentRegister.MapProfiles.Users;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UpdateUserDto, User>(MemberList.None)
            .ForAllMembers(s => 
                s.Condition((src, dest, srcMember) => srcMember != null));
    }
}