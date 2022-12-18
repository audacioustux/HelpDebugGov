using System.ComponentModel.DataAnnotations;
using HelpDebugGov.Domain.Auth;
using HelpDebugGov.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace HelpDebugGov.Domain.Entities;

[Index(nameof(Email), IsUnique = true)]
public class User : Entity
{
    public string Name { get; set; } = null!;
    public string? Handle { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Role { get; set; } = Roles.User;
}