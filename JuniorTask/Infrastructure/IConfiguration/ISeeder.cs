namespace JuniorTask.Infrastructure.IConfiguration
{
    public interface ISeeder
    {
        public int Index { get; set; }
        Task Seed();
    }
}
