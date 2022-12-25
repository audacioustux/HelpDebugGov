using System.ComponentModel.DataAnnotations;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace HelpDebugGov.Domain.Entities;

[Index(nameof(Name), IsUnique = true)]
public class Role
{
    public Guid Id { get; protected set; } = NewId.NextGuid();
    [MaxLength(31)]
    public required string Name { get; set; }
    [MaxLength(255)]
    public string? Description { get; set; }

    public virtual ICollection<Permission> Permissions { get; set; } = new HashSet<Permission>();
    public virtual ICollection<User> Users { get; set; } = new HashSet<User>();
}