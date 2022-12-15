namespace Api.Entities;

using Api.Db;
using Microsoft.EntityFrameworkCore;

[Index(nameof(Email), IsUnique = true)]
public class User : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}