using System.Linq.Expressions;
using JuniorTask.Infrastructure.IConfiguration;

namespace JuniorTask.Infrastructure.Repository
{
    public interface IGenericRepository<T, TKey>
        where T : class, IEntity<TKey> where TKey : notnull
    {
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        IQueryable<T> Query();
        Task<bool> AddRangeAsync(IEnumerable<T> entity);
        Task<bool> AddAsync(T entity);
        bool Remove(T entity);
    }
}
