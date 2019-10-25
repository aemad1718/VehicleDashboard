using System.Collections.Generic;
using VehicleDashboard.DatabaseEntity;

namespace VehicleDashboard.DatabaseRepositoryInterface
{
    public interface ICustomerRepository
    {
        List<Customer> GetAllCustomers();
    }
}
