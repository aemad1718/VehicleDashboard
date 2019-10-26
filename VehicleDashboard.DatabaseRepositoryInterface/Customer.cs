using System;
using System.Collections.Generic;

namespace VehicleDashboard.DatabaseRepositoryInterface
{
    public partial class Customer
    {
        public Customer()
        {
            CustomerAddress = new HashSet<CustomerAddress>();
            CustomerVehicle = new HashSet<CustomerVehicle>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }

        public virtual ICollection<CustomerAddress> CustomerAddress { get; set; }
        public virtual ICollection<CustomerVehicle> CustomerVehicle { get; set; }
    }
}