using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace VehicleDashboard.Gateway.Controllers
{
    public class BaseController : Controller
    {
        public readonly IHttpClientUtility _httClientUtility;

        public readonly string vehicleDashboardApiEndpoint;

        public BaseController(IHttpClientUtility httClientUtility, IConfiguration configuration)
        {
            _httClientUtility = httClientUtility;
            vehicleDashboardApiEndpoint = configuration["vehicleDashboardApiEndpoint"];
        }
    }
}
