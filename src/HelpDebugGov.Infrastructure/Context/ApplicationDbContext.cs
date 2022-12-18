using EntityFramework.Exceptions.PostgreSQL;
using HelpDebugGov.Application.Common;
using HelpDebugGov.Domain.Entities;
using HelpDebugGov.Domain.Entities.Common;
using HelpDebugGov.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace HelpDebugGov.Infrastructure.Context;

public class ApplicationDbContext : DbContext, IContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseExceptionProcessor();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfiguration).Assembly);
    }

    public override int SaveChanges()
    {
        AddTimestamps();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        AddTimestamps();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void AddTimestamps()
    {
        foreach (var entry in ChangeTracker.Entries())
        {
            if (entry.Entity is not Entity) continue;

            var now = DateTime.UtcNow;

            if (entry.State == EntityState.Added)
                ((Entity)entry.Entity).CreatedAt = now;
            if (entry.State == EntityState.Modified)
                ((Entity)entry.Entity).UpdatedAt = now;
        }
    }
}