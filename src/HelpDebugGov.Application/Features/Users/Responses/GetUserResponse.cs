namespace HelpDebugGov.Application.Features.Users.Responses;

public record GetUserResponse
{
    public Guid Id { get; init; }
    public required string Name { get; init; }
    public string? Handle { get; init; }
    public required string Email { get; init; }
}