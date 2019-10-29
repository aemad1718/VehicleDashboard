using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Reflection;
using VehicleDashboard.CrossCutting;
using VehicleDashboard.Gateway.Extensions;

namespace VehicleDashboard.Gateway
{
    /// <summary>
    /// Initialized at the begining of the application.
    /// Taking the responsibility of regestering the dependencies in the IOC container.
    /// Configure all the middleware layers.
    /// Register the global application configurations.
    /// </summary>
    public class Startup
    {
        private const string MyAllowSpecificOrigins = "MyAllowSpecificOrigins";

        /// <summary>
        /// Taking the responsibility of initializing the dependencies.
        /// </summary>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Holds all the application configurations.
        /// </summary>
        private IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// Register the global application configurations from appsettings.json file.
        /// Register the allowed domains.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IHttpClientUtility, HttpClientUtility>();
            services.AddScoped<ILoggerService, LoggerService>();

            var allowedDomains = Configuration["allowedDomains"].Split(',');

            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins(allowedDomains)
                                        .AllowAnyOrigin()
                                        .AllowAnyMethod()
                                        .AllowAnyHeader()
                                        .AllowCredentials();
                });
            });

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info { Title = "Vehicle Dashboard Gateway API", Version = "v1" });

                string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                options.IncludeXmlComments(xmlPath);
            });

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

            app.UseHttpsRedirection();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseMvc();

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Vehicle Dashboard Gateway API V1");
            });
        }
    }
}
