using JuniorTask.Infrastructure.Entities;
using JuniorTask.Infrastructure.Repository;

namespace JuniorTask.Infrastructure.IConfiguration
{
    public interface IUnitOfWork
    {
        public IGenericRepository<User, int> User { get; }
        public IGenericRepository<Gender, int> Gender { get; }

        System.Threading.Tasks.Task SaveAsync();
    }
}
