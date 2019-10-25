using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VehicleDashboard.DomainInterface;
using VehicleDashboard.DomainInterface.Models;

namespace VehicleDashboard.API.Controllers
{
    [Route("api/vehicle")]
    [ApiController]
    public class VehicleController : Controller
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult<List<VehicleModel>> GetAll()
        {
            return _vehicleService.GetAllVehicles();
        }

        [HttpGet("GetVehicles")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult<List<VehicleModel>> GetVehicles(bool? isConnected, int? customerId)
        {
            return _vehicleService.GetVehicles(isConnected, customerId);
        }
    }
}