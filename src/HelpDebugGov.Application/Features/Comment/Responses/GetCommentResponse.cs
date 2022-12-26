using HelpDebugGov.Domain.Entities;

namespace HelpDebugGov.Application.Features.Comments.Responses;

public record GetCommentResponse
{
    public Guid Id { get; init; }
    public required string Text { get; set; }
    public required CommentStatus Status { get; set; }

    public virtual required User User { get; set; }
    public virtual required Issue Issue { get; set; }
}