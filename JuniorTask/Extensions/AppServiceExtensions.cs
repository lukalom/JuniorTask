using JuniorTask.Application.Activity_Service;
using JuniorTask.Application.User_Service;
using JuniorTask.Infrastructure.Data;
using JuniorTask.Infrastructure.IConfiguration;

namespace JuniorTask.Extensions
{
    public static class AppServiceExtensions
    {
        public static IServiceCollection ApplicationServiceExtensions(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IActivityService, ActivityService>();
            services.AddHttpClient();

            return services;
        }
    }
}
