namespace Api.Services;

using System.Linq.Expressions;
using Api.Db;
using Microsoft.EntityFrameworkCore;

public interface IGenericService<T> where T : class
{
    Task<T?> GetById(int id);
    Task<IEnumerable<T>> GetAll();
    Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression);
    void Add(T entity);
    void AddRange(IEnumerable<T> entities);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);
}

public class GenericService<T> : IGenericService<T> where T : class
{
    protected readonly ApplicationContext _context;
    private readonly DbSet<T> _entitySet;

    public GenericService(ApplicationContext context)
    {
        _context = context;
        _entitySet = _context.Set<T>();
    }
    public void Add(T entity) => _entitySet.Add(entity);
    public void AddRange(IEnumerable<T> entities) =>
        _entitySet.AddRange(entities);
    public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression) => await _entitySet.Where(expression).ToListAsync();
    public async Task<IEnumerable<T>> GetAll() => await _entitySet.ToListAsync();
    public async Task<T?> GetById(int id) => await _entitySet.FindAsync(id);
    public void Remove(T entity) => _entitySet.Remove(entity);
    public void RemoveRange(IEnumerable<T> entities) => _entitySet.RemoveRange(entities);
}
