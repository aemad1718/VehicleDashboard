using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleDashboard.CrossCutting;
using VehicleDashboard.Gateway.Models;

namespace VehicleDashboard.Gateway.Controllers
{
    /// <summary>
    /// Handle all the http requests that are related to the vehicle data.
    /// Vehicles data are retrieved from the VehicleDashboard API.
    /// </summary>
    [Route("api/vehicle")]
    [ApiController]
    public class VehicleController : BaseController
    {
        /// <summary>
        /// Taking the responsiblity of initializing the dependencies.
        /// </summary>
        /// <param name="httpClientUtility"></param>
        /// <param name="configuration"></param>
        public VehicleController(IHttpClientUtility httpClientUtility, IConfiguration configuration)
            : base(httpClientUtility, configuration)
        {

        }

        /// <summary>
        /// Get all vehciles data.
        /// </summary>
        /// <returns>List of vehicles</returns>
        [HttpGet("GetAll")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<List<VehicleModel>> GetAll()
        {
            return await _httClientUtility.Get<List<VehicleModel>>($"{vehicleDashboardApiEndpoint}/vehicle/GetAll");
        }

        /// <summary>
        /// Gets the filtered vehicles data.
        /// Filter can be either by status or by the customer Id.
        /// </summary>
        /// <param name="isConnected">
        /// true --> connected 
        /// false --> not connected
        /// </param>
        /// <param name="customerId">the customer unique identifier</param>
        /// <returns>List of vehciles</returns>
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