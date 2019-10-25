using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using VehicleDashboard.DatabaseRepository;
using VehicleDashboard.DatabaseRepositoryInterface;

namespace VehicleDashboard.IOC
{
    internal static class RegisterDatabaseRepository
    {
        public static IServiceCollection RegisterDatabaseRepositoryServices(this IServiceCollection services, IConfiguration configuration)
        {
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = configuration.GetConnectionString("vehicleDashboardDbConnection");
            services.AddDbContext<VehicledashboardContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<IDbContext, VehicledashboardContext>();
            services.AddScoped<IGenericRepository, GenericRepository>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            return services;
        }
    }
}
