using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleDashboard.CrossCutting;
using VehicleDashboard.Gateway.Models;

namespace VehicleDashboard.Gateway.Controllers
{
    [Route("api/vehicle")]
    [ApiController]
    public class VehicleController : BaseController
    {
        public VehicleController(IHttpClientUtility httpClientUtility, IConfiguration configuration)
            : base(httpClientUtility, configuration)
        {

        }

        [HttpGet("GetAll")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<List<VehicleModel>> GetAll()
        {
            return await _httClientUtility.Get<List<VehicleModel>>($"{vehicleDashboardApiEndpoint}/vehicle/GetAll");
        }

        [HttpGet("GetVehicles")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<List<VehicleModel>> GetVehicles(bool? isConnected, int? customerId)
        {
            return await _httClientUtility.Get<List<VehicleModel>>($"{vehicleDashboardApiEndpoint}/vehicle/GetVehicles", new Dictionary<string, object>
            {
                {"customerId",customerId },
                {"isConnected",isConnected }
            });
        }
    }
}