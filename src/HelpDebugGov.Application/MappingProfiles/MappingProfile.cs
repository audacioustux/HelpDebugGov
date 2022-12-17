using AutoMapper;
using HelpDebugGov.Application.Features.Users.Requests;
using HelpDebugGov.Application.Features.Users.Responses;
using HelpDebugGov.Domain.Auth;
using HelpDebugGov.Domain.Entities;

namespace HelpDebugGov.Application.MappingProfiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // User Map
        CreateMap<User, GetUserResponse>().ForMember(dest => dest.IsAdmin, opt => opt.MapFrom(x => x.Role == Roles.Admin)).ReverseMap();
        CreateMap<CreateUserRequest, User>().ForMember(dest => dest.Role,
            opt => opt.MapFrom(org => org.IsAdmin ? Roles.Admin : Roles.User));
        CreateMap<UpdatePasswordRequest, User>();
    }
}