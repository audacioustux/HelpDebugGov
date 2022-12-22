using HelpDebugGov.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HelpDebugGov.Domain.Auth;

namespace HelpDebugGov.Infrastructure.Configuration;

public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
    public static readonly Permission[] _permissions =
    {
        new Permission { Action = "user.read", Description = "Read user data" },
        new Permission { Action = "user.delete", Description = "Delete user data" },
        new Permission { Action = "user.create", Description = "Create user data" },
        new Permission { Action = "user.update", Description = "Update user data" }
    };

    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.HasData(_permissions);
    }
}