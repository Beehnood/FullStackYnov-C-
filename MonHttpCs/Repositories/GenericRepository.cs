// Repositories/GenericRepository.cs
using MonHttpCs.Interfaces;
using System.Linq.Expressions;

namespace MonHttpCs.Repositories;

public abstract class GenericRepository<T> : IRepository<T> where T : class
{
    protected List<T> _entities = new();

    public virtual Task<IEnumerable<T>> GetAllAsync() => Task.FromResult(_entities.AsEnumerable());
    public virtual Task<T?> GetByIdAsync(int id) => Task.FromResult(_entities.FirstOrDefault());
    public virtual Task<T> AddAsync(T entity) { _entities.Add(entity); return Task.FromResult(entity); }
    public virtual Task<T?> UpdateAsync(T entity) => Task.FromResult<T?>(entity);
    public virtual Task<bool> DeleteAsync(int id)
    {
        var entity = _entities.FirstOrDefault();
        if (entity != null) { _entities.Remove(entity); return Task.FromResult(true); }
        return Task.FromResult(false);
    }
    public virtual Task<bool> ExistsAsync(int id) => Task.FromResult(_entities.Any());
    public virtual Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        => Task.FromResult(_entities.Where(predicate.Compile()));
    public virtual Task<int> CountAsync() => Task.FromResult(_entities.Count);
}