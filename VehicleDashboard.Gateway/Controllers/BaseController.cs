using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using VehicleDashboard.CrossCutting;

namespace VehicleDashboard.Gateway.Controllers
{
    /// <summary>
    /// Include all the common items that are needed across all controllers.
    /// </summary>
    public class BaseController : Controller
    {
        /// <summary>
        /// Allow executing a http call to any extenral API.
        /// </summary>
        protected readonly IHttpClientUtility HttClientUtility;

        /// <summary>
        /// The endpoint URL for the vehicle API.
        /// </summary>
        protected readonly string VehicleDashboardApiEndpoint;

        /// <summary>
        /// Taking the responsibility of:
        /// - Initializing the dependencies.
        /// - Getting the vehicle API endpoint URL from the configuration appsettings.json.
        /// </summary>
        /// <param name="httClientUtility"></param>
        /// <param name="configuration"></param>
        public BaseController(IHttpClientUtility httClientUtility, IConfiguration configuration)
        {
            HttClientUtility = httClientUtility;
            VehicleDashboardApiEndpoint = configuration["vehicleDashboardApiEndpoint"];
        }
    }
}
