using System.ComponentModel.DataAnnotations;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace HelpDebugGov.Domain.Entities;

[Index(nameof(Action), IsUnique = true)]
public class Permission
{
    public Guid Id { get; protected set; } = NewId.NextGuid();
    public required LTree Action { get; set; }
    [MaxLength(255)]
    public string? Description { get; set; }

    public virtual ICollection<Role> Roles { get; set; } = new HashSet<Role>();
    public virtual ICollection<User> Users { get; set; } = new HashSet<User>();
}