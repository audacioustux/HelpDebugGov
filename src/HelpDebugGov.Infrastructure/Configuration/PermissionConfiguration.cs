using HelpDebugGov.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HelpDebugGov.Domain.Auth;

namespace HelpDebugGov.Infrastructure.Configuration;

public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
    public static readonly Permission[] _permissions = Enumerable.Concat(
        Permissions.GeneratePermissionsForModule("User"),
        new Permission[] {
            new Permission { Action = "_", Description = "All permissions" }
        }
    ).ToArray();

    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.HasData(_permissions);
    }
}