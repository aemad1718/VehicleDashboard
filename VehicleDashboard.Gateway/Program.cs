using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace VehicleDashboard.Gateway
{
    /// <summary>
    /// Start point class of the application.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Start poing method of the application
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Creating the web host builder.
        /// Use the startup class to execute the global configurations.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        private static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
