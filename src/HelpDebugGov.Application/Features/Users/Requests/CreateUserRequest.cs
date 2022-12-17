namespace HelpDebugGov.Application.Features.Users.Requests;

using MediatR;
using Responses;

public record CreateUserRequest : IRequest<GetUserResponse>
{
    public string Name { get; init; } = null!;
    public string Email { get; init; } = null!;

    public string Password { get; init; } = null!;

    public bool IsAdmin { get; init; }
}