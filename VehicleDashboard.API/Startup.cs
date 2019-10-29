using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using VehicleDashboard.API.Extensions;
using VehicleDashboard.CrossCutting;
using VehicleDashboard.IOC;

namespace VehicleDashboard.API
{
    /// <summary>
    /// Initialized at the begining of the application.
    /// Taking the responsibility of registering the dependencies in the IOC container.
    /// Configure all the middleware layers.
    /// Register the global application configurations.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Taking the responsibility of initializing the dependencies.
        /// </summary>
        public Startup()
        {

        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// Register the global application configurations from appsettings.json file
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();

            services.RegisterServices(configuration);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// This method registers swagger.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="loggerService"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerService loggerService)
        {
            app.ConfigureExceptionHandler(loggerService);

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Vehicle Dashboard API V1");
            });

            app.UseHttpsRedirection();

            app.UseMvc();
        }
    }
}
