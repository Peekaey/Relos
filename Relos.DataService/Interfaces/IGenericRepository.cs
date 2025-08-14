using System.Linq.Expressions;

namespace Relos.DataService.Interfaces;

public interface IGenericRepository<T> where T : class
{
    void Add(T entity);
    void Update(T entity);
    Task UpdateAsync(T entity);
    Task UpdateRangeAsync(IEnumerable<T> entities);
    void Delete(T entity);
    T? GetById(int id);
    IQueryable<T> Get();
    IQueryable<T> Query(params Expression<Func<T, object>>[] includes);
    void UpdateRange(IEnumerable<T> entities);
    void AddRange(IEnumerable<T> entities);
    Task DeleteAsync(T entity);
}