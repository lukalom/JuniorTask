using JuniorTask.Infrastructure.Data;
using JuniorTask.Infrastructure.Data.DB_Seed;
using JuniorTask.Infrastructure.IConfiguration;
using JuniorTask.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace JuniorTask.Extensions
{
    public static class DatabaseServiceExtensions
    {
        public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IDbInitializer, DbInitializer>();
            return services;
        }

        public static IServiceCollection AddGenericRepository(this IServiceCollection service)
        {
            service.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));

            return service;
        }

        public static IServiceCollection AddSeederService(this IServiceCollection service)
        {
            service.AddScoped<ISeeder, GenderSeed>();
            return service;
        }
        public static async Task Seed(this IHost host, IServiceProvider serviceProvider)
        {
            var dbInitializer = serviceProvider.GetRequiredService<IDbInitializer>();
            await dbInitializer.Initialize();
        }
    }
}
