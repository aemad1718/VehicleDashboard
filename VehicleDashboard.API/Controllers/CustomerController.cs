using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VehicleDashboard.DomainInterface;
using VehicleDashboard.DomainInterface.Models;

namespace VehicleDashboard.API.Controllers
{
    /// <summary>
    /// Handle all the http requests that are related to the customer data.
    /// </summary>
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        /// <summary>
        /// Taking the responsibility of initializing the dependencies.
        /// </summary>
        /// <param name="customerService"></param>
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        /// <summary>
        /// Call the domain layer to get the all customers data.
        /// </summary>
        /// <returns>List of customers</returns>
        [HttpGet("GetAll")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult<List<CustomerModel>> GetAll()
        {
            return _customerService.GetAllCustomers();
        }
    }
}