using System.ComponentModel.DataAnnotations;
using MassTransit;

namespace HelpDebugGov.Domain.Entities;

public class Role
{
    public Guid Id { get; protected set; } = NewId.NextGuid();
    [MaxLength(63)]
    public required string Name { get; set; }
    [MaxLength(255)]
    public required string? Description { get; set; }

    public virtual ICollection<Permission> Permissions { get; set; } = new HashSet<Permission>();
    public virtual ICollection<User> Users { get; set; } = new HashSet<User>();
}