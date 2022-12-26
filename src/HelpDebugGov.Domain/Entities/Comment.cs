using System.ComponentModel.DataAnnotations;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace HelpDebugGov.Domain.Entities;

public enum CommentStatus
{
    Visible,
    Deleted,
    Hidden,
    Draft
}

public class Comment
{
    public Guid Id { get; protected set; } = NewId.NextGuid();

    [MaxLength(4095)]
    public required string Text { get; set; }

    public required CommentStatus Status { get; set; }

    public virtual required User User { get; set; }
    public virtual required Issue Issue { get; set; }
}