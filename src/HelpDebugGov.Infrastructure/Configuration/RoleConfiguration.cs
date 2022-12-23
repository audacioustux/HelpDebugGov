using HelpDebugGov.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HelpDebugGov.Domain.Auth;

namespace HelpDebugGov.Infrastructure.Configuration;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public static readonly Role[] _roles =
    {
        new Role { Name = Roles.User, Description = "Any logged-in user" },
        new Role { Name = Roles.Superuser, Description = "Has all permissions" }
    };

    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasData(_roles);

        builder
            .HasMany(r => r.Permissions)
            .WithMany(p => p.Roles)
            .UsingEntity(j =>
            {
                j.HasData(new
                {
                    PermissionsId = PermissionConfiguration._permissions.Single(p => p.Action == "_").Id,
                    RolesId = _roles.Single(r => r.Name == Roles.Superuser).Id
                });
            });
    }
}