using HelpDebugGov.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HelpDebugGov.Domain.Auth;

namespace HelpDebugGov.Infrastructure.Configuration;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public static readonly Role[] _roles =
    {
        new Role { Name = Roles.User, Description = "User" },
        new Role { Name = Roles.Superuser, Description = "Superuser" }
    };

    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasData(_roles);

        builder
            .HasMany(r => r.Permissions)
            .WithMany(p => p.Roles)
            .UsingEntity(j =>
            {
                j.HasData(
                    PermissionConfiguration._permissions
                        .Select(p => new
                        {
                            PermissionsId = p.Id,
                            RolesId = _roles.Single(r => r.Name == Roles.Superuser).Id
                        })
                );
            });
    }
}