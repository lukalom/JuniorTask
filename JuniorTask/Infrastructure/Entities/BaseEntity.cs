using JuniorTask.Infrastructure.IConfiguration;

namespace JuniorTask.Infrastructure.Entities
{
    public class BaseEntity<T> : IEntity<T> where T : notnull
    {
        public T Id { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; }
    }
}
