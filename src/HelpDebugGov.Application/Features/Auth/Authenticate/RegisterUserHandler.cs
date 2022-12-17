namespace HelpDebugGov.Application.Features.Auth.Authenticate;

using AutoMapper;
using HelpDebugGov.Application.Common;
using HelpDebugGov.Domain.Entities;
using MediatR;
using BCrypt.Net;
using HelpDebugGov.Application.Features.Users.Responses;

public class RegisterUserHandler : IRequestHandler<RegisterUserRequest, GetUserResponse>
{
    private readonly IContext _context;
    private readonly IMapper _mapper;
    
    public RegisterUserHandler(IMapper mapper, IContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    
    public async Task<GetUserResponse> Handle(RegisterUserRequest request, CancellationToken cancellationToken)
    {
        var created = _mapper.Map<User>(request);
        _context.Users.Add(created);
        created.Password = BCrypt.HashPassword(request.Password);
        await _context.SaveChangesAsync(cancellationToken);
        return _mapper.Map<GetUserResponse>(created);
    }
}