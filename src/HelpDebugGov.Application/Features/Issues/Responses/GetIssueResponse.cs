using HelpDebugGov.Domain.Entities;

namespace HelpDebugGov.Application.Features.Issues.Responses;

public record GetIssueResponse
{
    public Guid Id { get; init; }

    public required string Title { get; set; }
    public required string Description { get; set; }
    public required IssueStatus Status { get; set; }

    // TODO: use UserDTO (password shouldn't be exposed to client)
    /// rename GetUserResponse to UserDTO
    public virtual required User User { get; set; }
    public virtual required Organization Organization { get; set; }
}