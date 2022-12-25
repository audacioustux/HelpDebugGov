namespace HelpDebugGov.Application.Features.Auth.Authenticate;

using HelpDebugGov.Application.Features.Users.Responses;
using MediatR;

public record UpdatePasswordRequest : IRequest<GetUserResponse>
{
    public Guid Id { get; init; }
    public required string Password { get; init; }
}