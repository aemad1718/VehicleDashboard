using System.Collections.Generic;
using VehicleDashboard.DatabaseRepositoryInterface;

namespace VehicleDashboard.DatabaseRepository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IGenericRepository _genericRepository;

        public CustomerRepository(IGenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public List<Customer> GetAllCustomers()
        {
           return _genericRepository.GetList<Customer>();
        }
    }
}
