using System.Collections.Generic;

namespace VehicleDashboard.DatabaseRepositoryInterface
{
    public interface ICustomerRepository
    {
        List<Customer> GetAllCustomers();
    }
}
