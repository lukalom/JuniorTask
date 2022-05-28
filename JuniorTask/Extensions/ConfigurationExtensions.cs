using JuniorTask.Shared;

namespace JuniorTask.Extensions
{
    public static class ConfigurationExtensions
    {
        public static IServiceCollection ConfigurationServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<Activity>(configuration.GetSection(nameof(Activity)));

            return services;
        }
    }
}
