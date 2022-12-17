using HelpDebugGov.Application.Common.Responses;
using MediatR;

namespace HelpDebugGov.Application.Features.Auth.Authenticate;

public record AuthenticateRequest : IRequest<Jwt?>
{
    public string Email { get; init; } = null!;

    public string Password { get; init; } = null!;
}