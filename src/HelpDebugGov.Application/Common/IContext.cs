using HelpDebugGov.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace HelpDebugGov.Application.Common;

public interface IContext : IAsyncDisposable, IDisposable
{
    public DatabaseFacade Database { get; }
    public DbSet<User> Users { get; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}