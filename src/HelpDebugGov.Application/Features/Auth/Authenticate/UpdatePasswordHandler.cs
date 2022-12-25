namespace HelpDebugGov.Application.Features.Auth.Authenticate;

using AutoMapper;
using BCrypt.Net;
using FluentEmail.Core;
using HelpDebugGov.Application.Common;
using HelpDebugGov.Application.Features.Users.Responses;
using HelpDebugGov.Domain.Auth;
using HelpDebugGov.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

public class UpdatePasswordHandler : IRequestHandler<UpdatePasswordRequest, GetUserResponse>
{
    private readonly IContext _context;
    private readonly IMapper _mapper;
    private readonly IFluentEmail _fluentEmail;
    private readonly ILogger<RegisterUserHandler> _logger;

    public UpdatePasswordHandler(IMapper mapper, IContext context, IFluentEmail fluentEmail, ILogger<RegisterUserHandler> logger)
    {
        _mapper = mapper;
        _context = context;
        _fluentEmail = fluentEmail;
        _logger = logger;
    }

    public async Task<GetUserResponse> Handle(UpdatePasswordRequest request, CancellationToken cancellationToken)
    {
        var originalUser = await _context.Users
            .FirstAsync(x => x.Id == request.Id, cancellationToken);
        originalUser.Password = BCrypt.EnhancedHashPassword(request.Password);
        _context.Users.Update(originalUser);
        await _context.SaveChangesAsync(cancellationToken);
        return _mapper.Map<GetUserResponse>(originalUser);
    }
}