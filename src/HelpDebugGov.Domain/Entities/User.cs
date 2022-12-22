using System.ComponentModel.DataAnnotations;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace HelpDebugGov.Domain.Entities;

[Index(nameof(Email), IsUnique = true)]
[Index(nameof(Handle), IsUnique = true)]
public class User
{
    public Guid Id { get; protected set; } = NewId.NextGuid();
    [MaxLength(127)]
    public required string Name { get; set; }
    [MaxLength(31)]
    public string? Handle { get; set; }
    [MaxLength(255)]
    public required string Email { get; set; }
    public required string Password { get; set; }

    public virtual ICollection<Role> Roles { get; set; } = new HashSet<Role>();
    public virtual ICollection<Permission> Permissions { get; set; } = new HashSet<Permission>();
}