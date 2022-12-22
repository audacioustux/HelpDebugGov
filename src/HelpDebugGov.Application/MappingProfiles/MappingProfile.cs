using AutoMapper;
using HelpDebugGov.Application.Features.Auth.Authenticate;
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
        CreateMap<User, GetUserResponse>();
        CreateMap<CreateUserRequest, User>();
        CreateMap<RegisterUserRequest, User>();
        CreateMap<UpdatePasswordRequest, User>();
    }
}