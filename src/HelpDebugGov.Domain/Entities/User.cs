using System.ComponentModel.DataAnnotations;
using HelpDebugGov.Domain.Auth;
using HelpDebugGov.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace HelpDebugGov.Domain.Entities;

[Index(nameof(Email), IsUnique = true)]
[Index(nameof(Handle), IsUnique = true)]
public class User : Entity
{
    [MaxLength(128)]
    public required string Name { get; set; }
    [MaxLength(64)]
    public string? Handle { get; set; }
    [MaxLength(255)]
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string Role { get; set; } = Roles.User;
}