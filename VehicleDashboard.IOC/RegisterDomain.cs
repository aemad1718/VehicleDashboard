using Microsoft.Extensions.DependencyInjection;
using VehicleDashboard.Domain;
using VehicleDashboard.DomainInterface;

namespace VehicleDashboard.IOC
{
    internal static class RegisterDomain
    {
        public static IServiceCollection RegisterDomainServices(this IServiceCollection services)
        {
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<ICustomerService, CustomerService>();

            return services;
        }
    }
}
