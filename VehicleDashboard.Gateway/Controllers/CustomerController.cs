using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleDashboard.CrossCutting;
using VehicleDashboard.Gateway.Models;

namespace VehicleDashboard.Gateway.Controllers
{
    /// <summary>
    /// Handle all the http requests that are related to the customer data.
    /// Customers data are retrieved from the VehicleDashboard API.
    /// </summary>
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : BaseController
    {
        /// <summary>
        /// Taking the responsibility of initializing the dependencies.
        /// </summary>
        /// <param name="httpClientUtility"></param>
        /// <param name="configuration"></param>
        public CustomerController(IHttpClientUtility httpClientUtility, IConfiguration configuration)
            : base(httpClientUtility, configuration)
        {
        }

        /// <summary>
        /// Get all customers data.
        /// </summary>
        /// <returns>List of customers</returns>
        [HttpGet("GetAll")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<List<CustomerModel>> GetAllAsync()
        {
            return await HttClientUtility.Get<List<CustomerModel>>($"{VehicleDashboardApiEndpoint}/customer/GetAll");
        }
    }
}