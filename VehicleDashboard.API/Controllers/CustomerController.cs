using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VehicleDashboard.DomainInterface;
using VehicleDashboard.DomainInterface.Models;

namespace VehicleDashboard.API.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult<List<CustomerModel>> GetAll()
        {
            return _customerService.GetAllCustomers();
        }
    }
}