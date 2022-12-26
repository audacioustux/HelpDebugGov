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

        var superuserPermissions = new
        {
            PermissionsId = PermissionConfiguration._permissions.Single(p => p.Action == "_").Id,
            RolesId = _roles.Single(r => r.Name == Roles.Superuser).Id
        };

        var userPermissions = new string[] {
            "User.Read.ById", "User.Update.Own", "User.Delete.Own",
            "Comment.Create", "Comment.Read", "Comment.Update.Own", "Comment.Delete.Own",
            "Issue.Create", "Issue.Read", "Issue.Update.Own", "Issue.Delete.Own",
            "Organization.Read"
        }.Select(action => new
        {
            PermissionsId = PermissionConfiguration._permissions.Single(p => p.Action == action).Id,
            RolesId = _roles.Single(r => r.Name == Roles.User).Id
        }).ToArray();

        builder
            .HasMany(r => r.Permissions)
            .WithMany(p => p.Roles)
            .UsingEntity(j =>
            {
                j.HasData(superuserPermissions);
                j.HasData(userPermissions);
            });
    }
}