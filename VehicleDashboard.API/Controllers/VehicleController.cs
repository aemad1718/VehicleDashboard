using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VehicleDashboard.DomainInterface;
using VehicleDashboard.DomainInterface.Models;

namespace VehicleDashboard.API.Controllers
{
    /// <summary>
    /// Handle all the http requests that are related to the vehicle data.
    /// </summary>
    [Route("api/vehicle")]
    [ApiController]
    public class VehicleController : Controller
    {
        private readonly IVehicleService _vehicleService;

        /// <summary>
        /// Taking the responsiblity of initializing the dependencies.
        /// </summary>
        /// <param name="vehicleService"></param>
        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        /// <summary>
        /// Call the domain layer to get the all vehicles data.
        /// </summary>
        /// <returns>List of vehicles</returns>
        [HttpGet("GetAll")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult<List<VehicleModel>> GetAll()
        {
            return _vehicleService.GetAllVehicles();
        }

        /// <summary>
        /// Call the domain layer to get the filtered vehicles data.
        /// Filter can be either by status or by the customer Id.
        /// </summary>
        /// <param name="isConnected">
        /// true --> connected 
        /// false --> not connected
        /// </param>
        /// <param name="customerId">the customer unique identifier</param>
        /// <returns>List of vehicles</returns>
        [HttpGet("GetVehicles")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult<List<VehicleModel>> GetVehicles(bool? isConnected, int? customerId)
        {
            return _vehicleService.GetVehicles(isConnected, customerId);
        }
    }
}