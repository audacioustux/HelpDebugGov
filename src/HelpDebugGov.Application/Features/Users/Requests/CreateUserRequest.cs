namespace HelpDebugGov.Application.Features.Users.Requests;

using MediatR;
using Responses;

public record CreateUserRequest : IRequest<GetUserResponse>
{
    public required string Name { get; init; }
    public string? Handle { get; init; }
    public required string Email { get; init; }
    public required string Password { get; init; }
}