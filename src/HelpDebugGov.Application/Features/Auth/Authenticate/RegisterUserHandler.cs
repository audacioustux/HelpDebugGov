namespace HelpDebugGov.Application.Features.Auth.Authenticate;

using AutoMapper;
using BCrypt.Net;
using FluentEmail.Core;
using HelpDebugGov.Application.Common;
using HelpDebugGov.Application.Features.Users.Responses;
using HelpDebugGov.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

public class RegisterUserHandler : IRequestHandler<RegisterUserRequest, GetUserResponse>
{
    private readonly IContext _context;
    private readonly IMapper _mapper;
    private readonly IFluentEmail _fluentEmail;
    private readonly ILogger<RegisterUserHandler> _logger;

    public RegisterUserHandler(IMapper mapper, IContext context, IFluentEmail fluentEmail, ILogger<RegisterUserHandler> logger)
    {
        _mapper = mapper;
        _context = context;
        _fluentEmail = fluentEmail;
        _logger = logger;
    }

    public async Task<GetUserResponse> Handle(RegisterUserRequest request, CancellationToken cancellationToken)
    {
        var created = _mapper.Map<User>(request);
        _context.Users.Add(created);
        created.Password = BCrypt.EnhancedHashPassword(request.Password);
        await _context.SaveChangesAsync(cancellationToken);
        await _fluentEmail
            .To(created.Email, created.Name)
            .Subject("Welcome to HelpDebugGov!")
            .Body("Welcome to HelpDebugGov!")
            .SendAsync().ContinueWith(t =>
            {
                if (t.Result.Successful)
                    _logger.LogInformation("Email sent to {Email}", created.Email);
                else
                    _logger.LogError(
                        "Email failed to send to {Email}: {Reasons}",
                        created.Email,
                        string.Join(",", t.Result.ErrorMessages));
            });

        return _mapper.Map<GetUserResponse>(created);
    }
}