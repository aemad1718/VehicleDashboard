using System.Collections.Generic;
using VehicleDashboard.DatabaseRepositoryInterface;
using VehicleDashboard.DomainInterface;
using VehicleDashboard.DomainInterface.Models;

namespace VehicleDashboard.Domain
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public List<CustomerModel> GetAllCustomers()
        {
            return _customerRepository.GetAllCustomers().ToCustomerModels();
        }
    }
}
