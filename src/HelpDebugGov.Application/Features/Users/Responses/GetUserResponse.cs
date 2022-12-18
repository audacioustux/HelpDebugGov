namespace HelpDebugGov.Application.Features.Users.Responses;

public record GetUserResponse
{
    public Guid Id { get; init; }
    public string Name { get; init; } = null!;
    public string? Handle { get; init; } = null!;
    public string Email { get; init; } = null!;
    public bool IsAdmin { get; init; }
}