using HelpDebugGov.Application.Common.Responses;
using MediatR;

namespace HelpDebugGov.Application.Features.Auth.Authenticate;

public record AuthenticateRequest : IRequest<Jwt?>
{
    public required string Email { get; init; }
    public required string Password { get; init; }
}