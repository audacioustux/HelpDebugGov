namespace HelpDebugGov.Application.Features.Users.Requests;

using AutoMapper;
using HelpDebugGov.Application.Common;
using HelpDebugGov.Domain.Entities;
using MediatR;
using BCrypt.Net;
using Responses;

public class CreateUserHandler : IRequestHandler<CreateUserRequest, GetUserResponse>
{
    private readonly IContext _context;
    private readonly IMapper _mapper;
    
    
    public CreateUserHandler(IMapper mapper, IContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    public async Task<GetUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var created = _mapper.Map<User>(request);
        _context.Users.Add(created);
        created.Password = BCrypt.HashPassword(request.Password);
        await _context.SaveChangesAsync(cancellationToken);
        return _mapper.Map<GetUserResponse>(created);
    }
}