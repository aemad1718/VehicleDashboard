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
        public readonly IHttpClientUtility _httClientUtility;

        /// <summary>
        /// The endpoint URL for the vehicle API.
        /// </summary>
        public readonly string vehicleDashboardApiEndpoint;

        /// <summary>
        /// Taking the responsibility of:
        /// - Initializing the dependencies.
        /// - Getting the vehicle API endpoint URL from the configuration appsettings.json.
        /// </summary>
        /// <param name="httClientUtility"></param>
        /// <param name="configuration"></param>
        public BaseController(IHttpClientUtility httClientUtility, IConfiguration configuration)
        {
            _httClientUtility = httClientUtility;
            vehicleDashboardApiEndpoint = configuration["vehicleDashboardApiEndpoint"];
        }
    }
}
