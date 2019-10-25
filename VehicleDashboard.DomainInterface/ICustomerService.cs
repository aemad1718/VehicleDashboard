using System.Collections.Generic;
using VehicleDashboard.DomainInterface.Models;

namespace VehicleDashboard.DomainInterface
{
    public interface ICustomerService
    {
        List<CustomerModel> GetAllCustomers();
    }
}
