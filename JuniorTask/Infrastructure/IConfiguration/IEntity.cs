namespace JuniorTask.Infrastructure.IConfiguration
{
    public interface IEntity<T> where T : notnull
    {
        public T Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
