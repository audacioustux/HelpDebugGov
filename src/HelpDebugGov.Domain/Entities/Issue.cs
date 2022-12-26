using System.ComponentModel.DataAnnotations;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace HelpDebugGov.Domain.Entities;

public enum IssueStatus
{
    Open,
    Closed
}

public class Issue
{
    public Guid Id { get; protected set; } = NewId.NextGuid();
    [MaxLength(255)]
    public required string Title { get; set; }
    [MaxLength(4095)]
    public required string Description { get; set; }
    public required IssueStatus Status { get; set; }

    public virtual required User User { get; set; }
    public virtual required Organization Organization { get; set; }
}