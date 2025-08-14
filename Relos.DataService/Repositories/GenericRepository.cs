using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Relos.DataService.Interfaces;

namespace Relos.DataService.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly DataContext _context;
    protected readonly DbSet<T>     _dbSet;
    
    public GenericRepository(DataContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }
    
    public IQueryable<T> Get()
    {
        return _dbSet;
    }
    
    public IQueryable<T> Query(params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> q = _dbSet.AsNoTracking();
        foreach (var inc in includes)
            q = q.Include(inc);
        return q;
    }
    
    public void Add(T entity)
    {
        _dbSet.Add(entity);
    }
    
    public void AddRange(IEnumerable<T> entities)
    {
        _dbSet.AddRange(entities);
    }

    public void Update(T entity)
    {
        //TODO Implement Check for IAuditable at later date for updating
        _dbSet.Update(entity);
    }
    
    public async Task UpdateAsync(T entity)
    {
        //TODO Implement Check for IAuditable at later date for updating
        _dbSet.Update(entity);
    }
    
    public async Task UpdateRangeAsync(IEnumerable<T> entities)
    {
        //TODO Implement Check for IAuditable at later date for updating
        _dbSet.UpdateRange(entities);
    }
    
    public void UpdateRange(IEnumerable<T> entities)
    {
        //TODO Implement Check for IAuditable at later date for updating
        _dbSet.UpdateRange(entities);
    }
    
    public async Task DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
    }
    
    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }
    
    public T? GetById(int id)
    {
        return _dbSet.Find(id);
    }
    
    
    
}