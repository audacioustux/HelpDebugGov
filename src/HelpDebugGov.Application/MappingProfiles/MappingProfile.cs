using AutoMapper;
using HelpDebugGov.Application.Common;
using HelpDebugGov.Application.Features.Auth.Authenticate;
using HelpDebugGov.Application.Features.Comments.Requests;
using HelpDebugGov.Application.Features.Comments.Responses;
using HelpDebugGov.Application.Features.Issues.Requests;
using HelpDebugGov.Application.Features.Issues.Responses;
using HelpDebugGov.Application.Features.Organizations.Requests;
using HelpDebugGov.Application.Features.Organizations.Responses;
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
        // Auth Map
        CreateMap<RegisterUserRequest, User>();
        CreateMap<UpdatePasswordRequest, User>();
        // Organization Map
        CreateMap<Organization, GetOrganizationResponse>();
        // CreateMap<CreateOrganizationRequest, Organization>();
        // Issue Map
        CreateMap<Issue, GetIssueResponse>();
        // CreateMap<CreateIssueRequest, Issue>();
        // Comment Map
        CreateMap<Comment, GetCommentResponse>();
        // CreateMap<CreateCommentRequest, Comment>();
    }
}