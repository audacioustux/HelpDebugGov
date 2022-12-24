using HelpDebugGov.Domain.Auth;
using HelpDebugGov.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpDebugGov.Infrastructure.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    private readonly static string superuserName = Environment.GetEnvironmentVariable("SUPERUSER_NAME")!;
    private readonly static string superuserEmail = Environment.GetEnvironmentVariable("SUPERUSER_EMAIL")!;
    private readonly static string? superuserHandle = Environment.GetEnvironmentVariable("SUPERUSER_HANDLE");
    private readonly static string superuserPassword = BCrypt.Net.BCrypt.EnhancedHashPassword(
        Environment.GetEnvironmentVariable("SUPERUSER_PASSWORD") ?? RandomString(32)
    );

    private static string RandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[new Random().Next(s.Length)]).ToArray());
    }
    public static readonly User[] _users =
    {
        new User {
            Name = superuserName,
            Handle = superuserHandle,
            Email = superuserEmail,
            Password = superuserPassword
        }
    };

    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasData(_users);

        builder
            .HasMany(u => u.Roles)
            .WithMany(r => r.Users)
            .UsingEntity(j =>
            {
                j.HasData(new
                {
                    UsersId = _users.Single(u => u.Handle == superuserHandle).Id,
                    RolesId = RoleConfiguration._roles.Single(r => r.Name == Roles.Superuser).Id
                });
            });
    }
}