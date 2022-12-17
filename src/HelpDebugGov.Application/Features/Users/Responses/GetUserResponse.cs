namespace HelpDebugGov.Application.Features.Users.Responses;

public record GetUserResponse
{
    public Guid Id { get; init; }

    public string Email { get; init; } = null!;

    public bool IsAdmin { get; init; }
}