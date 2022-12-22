using EntityFramework.Exceptions.PostgreSQL;
using HelpDebugGov.Application.Common;
using HelpDebugGov.Domain.Entities;
using HelpDebugGov.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace HelpDebugGov.Infrastructure.Context;

public class ApplicationDbContext : DbContext, IContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public required DbSet<User> Users { get; set; }
    public required DbSet<Role> Roles { get; set; }
    public required DbSet<Permission> Permissions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseExceptionProcessor();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new PermissionConfiguration().Configure(modelBuilder.Entity<Permission>());
        new RoleConfiguration().Configure(modelBuilder.Entity<Role>());
        new UserConfiguration().Configure(modelBuilder.Entity<User>());
    }
}