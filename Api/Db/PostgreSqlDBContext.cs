namespace HelpDebugGov.Db;

using Microsoft.EntityFrameworkCore;
using zero_hunger.Models;

public class PostgreSqlDBContext : DbContext
{
    public DbSet<User> User { get; set; } = null!;
    public DbSet<File> File { get; set; } = null!;
    public DbSet<Organization> Organization { get; set; } = null!;
    public DbSet<Issue> Issue { get; set; } = null!;
    public DbSet<Label> Label { get; set; } = null!;
    public DbSet<Subscription> Subscription { get; set; } = null!;
    public DbSet<LabelToIssue> LabelToIssue { get; set; } = null!;
    public DbSet<Role> Role { get; set; } = null!;
    public DbSet<UserToRole> UserToRole { get; set; } = null!;
    public DbSet<Permission> Permission { get; set; } = null!;
    public DbSet<RoleToPermission> RoleToPermission { get; set; } = null!;
    public DbSet<Comment> Comment { get; set; } = null!;

    public PostgreSqlDBContext(DbContextOptions<PostgreSqlDBContext> options) : base(options) { }

    public override int SaveChanges()
    {
        AddTimestamps();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        AddTimestamps();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void AddTimestamps()
    {
        var entities = ChangeTracker.Entries()
            .Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

        foreach (var entity in entities)
        {
            var now = DateTime.UtcNow;

            if (entity.State == EntityState.Added)
            {
                ((BaseEntity)entity.Entity).CreatedAt = now;
            }
            ((BaseEntity)entity.Entity).UpdatedAt = now;
        }
    }
}
