using System.Linq.Expressions;
using JuniorTask.Infrastructure.Data;
using JuniorTask.Infrastructure.IConfiguration;
using Microsoft.EntityFrameworkCore;

namespace JuniorTask.Infrastructure.Repository
{
    public class GenericRepository<T, TKey> : IGenericRepository<T, TKey>
        where T : class, IEntity<TKey> where TKey : notnull
    {
        protected readonly ApplicationDbContext Db;
        internal DbSet<T> DbSet;

        public GenericRepository(ApplicationDbContext db)
        {
            Db = db;
            DbSet = Db.Set<T>();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
            DbSet.Where(expression).AsQueryable();

        public IQueryable<T> Query() => DbSet.AsQueryable();

        public virtual async Task<bool> AddAsync(T entity)
        {
            await DbSet.AddAsync(entity);
            return true;
        }

        public virtual async Task<bool> AddRangeAsync(IEnumerable<T> entity)
        {
            await DbSet.AddRangeAsync(entity);
            return true;
        }

        public virtual bool Remove(T entity)
        {
            DbSet.Remove(entity);
            return true;
        }
    }
}
