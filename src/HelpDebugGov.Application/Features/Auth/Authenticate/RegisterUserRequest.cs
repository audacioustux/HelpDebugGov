namespace HelpDebugGov.Application.Features.Auth.Authenticate;

using HelpDebugGov.Application.Features.Users.Responses;
using MediatR;

public record RegisterUserRequest : IRequest<GetUserResponse>
{
    public string Name { get; init; } = null!;
    public string? Handle { get; init; } = null!;
    public string Email { get; init; } = null!;

    public string Password { get; init; } = null!;
}