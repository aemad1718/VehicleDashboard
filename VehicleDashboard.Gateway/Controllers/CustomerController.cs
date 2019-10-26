using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using VehicleDashboard.Gateway.Models;

namespace VehicleDashboard.Gateway.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : BaseController
    {
        public CustomerController(IHttpClientUtility httpClientUtility, IConfiguration configuration) 
            : base(httpClientUtility, configuration)
        {

        }

        [HttpGet("GetAll")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<List<CustomerModel>> GetAllAsync()
        {
            return await _httClientUtility.Get<List<CustomerModel>>($"{vehicleDashboardApiEndpoint}/customer/GetAll");
        }
    }
}