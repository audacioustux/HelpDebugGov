namespace Api.Db;

using Api.Entities;
using Microsoft.EntityFrameworkCore;

public class ApplicationContext : DbContext
{
  public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

  public DbSet<User> Users { get; set; } = null!;

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
