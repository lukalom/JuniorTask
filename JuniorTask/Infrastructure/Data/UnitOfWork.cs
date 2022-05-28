using JuniorTask.Infrastructure.Entities;
using JuniorTask.Infrastructure.IConfiguration;
using JuniorTask.Infrastructure.Repository;

namespace JuniorTask.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _db;
        private readonly IServiceProvider _serviceProvider;

        public UnitOfWork(ApplicationDbContext db,
            IServiceProvider serviceProvider)
        {
            _db = db;
            _serviceProvider = serviceProvider;
        }
        public IGenericRepository<User, int> User => _serviceProvider.GetRequiredService<IGenericRepository<User, int>>();
        public IGenericRepository<Gender, int> Gender => _serviceProvider.GetRequiredService<IGenericRepository<Gender, int>>();

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
