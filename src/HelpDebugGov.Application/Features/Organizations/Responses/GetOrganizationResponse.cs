namespace HelpDebugGov.Application.Features.Organizations.Responses;

public record GetOrganizationResponse
{
    public Guid Id { get; init; }
    public required string Name { get; init; }
    public string? Description { get; init; }
}