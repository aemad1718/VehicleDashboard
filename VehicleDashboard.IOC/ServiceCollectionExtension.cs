using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace VehicleDashboard.IOC
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterDatabaseRepositoryServices(configuration);
            services.RegisterSwaggerServices();
            services.RegisterDomainServices();

            return services;
        }
    }
}
