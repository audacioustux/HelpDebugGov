namespace HelpDebugGov.Application.Features.Auth.Authenticate;

using AutoMapper;
using BCrypt.Net;
using HelpDebugGov.Application.Common;
using HelpDebugGov.Application.Email;
using HelpDebugGov.Application.Features.Users.Responses;
using HelpDebugGov.Domain.Entities;
using MediatR;
using SendGrid.Helpers.Mail;

public class RegisterUserHandler : IRequestHandler<RegisterUserRequest, GetUserResponse>
{
    private readonly IContext _context;
    private readonly IMapper _mapper;
    private readonly IEmailManager _emailManager;

    public RegisterUserHandler(IMapper mapper, IContext context, IEmailManager emailManager)
    {
        _mapper = mapper;
        _context = context;
        _emailManager = emailManager;
    }

    public async Task<GetUserResponse> Handle(RegisterUserRequest request, CancellationToken cancellationToken)
    {
        var created = _mapper.Map<User>(request);
        _context.Users.Add(created);
        created.Password = BCrypt.EnhancedHashPassword(request.Password);
        await _context.SaveChangesAsync(cancellationToken);
        await _emailManager.SendEmail(new EmailToSend
        {
            FromEmail = "tanjim@audacioustux.com",
            FromName = "AudaciousTux",
            Subject = "Welcome to HelpDebugGov",
            Body = "Welcome to HelpDebugGov",
            Recipients = new List<(string ToEmail, string ToName)>
            {
                (created.Email, created.Name)
            }
        });
        return _mapper.Map<GetUserResponse>(created);
    }
}