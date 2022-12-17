using HelpDebugGov.Domain.Entities.Common;

namespace HelpDebugGov.Domain.Entities;

public class User : Entity
{
    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Role { get; set; } = null!;
}