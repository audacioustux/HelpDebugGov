namespace Api.Services;

using Api.Db;

public interface IUnitOfWork : IDisposable
{
    IUserService Users { get; }
    Task<int> Save();
}

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationContext _context;
    private IUserService? _userService;

    public UnitOfWork(ApplicationContext context)
    {
        _context = context;
        Users = new UserService(_context);
    }

    public IUserService Users { get; private set; }

    public async Task<int> Save()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}