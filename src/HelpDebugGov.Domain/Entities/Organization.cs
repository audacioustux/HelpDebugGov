using System.ComponentModel.DataAnnotations;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace HelpDebugGov.Domain.Entities;

public class Organization
{
    public Guid Id { get; protected set; } = NewId.NextGuid();
    [MaxLength(127)]
    public required string Name { get; set; }
    [MaxLength(255)]
    public string? Description { get; set; }
}