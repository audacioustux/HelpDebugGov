namespace HelpDebugGov.Application.Features.Comments.Requests;

using System.ComponentModel.DataAnnotations;
using HelpDebugGov.Domain.Entities;
using MediatR;
using Responses;

public record CreateCommentRequest : IRequest<GetCommentResponse>
{
    [MaxLength(4095)]
    public required string Text { get; set; }

    public required CommentStatus Status { get; set; }

    public virtual required Guid UserId { get; set; }
    public virtual required Guid IssueId { get; set; }
}