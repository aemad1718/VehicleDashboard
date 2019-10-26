using System;
using System.Collections.Generic;

namespace VehicleDashboard.DatabaseRepositoryInterface
{
    public partial class Vehicle
    {
        public Vehicle()
        {
            CustomerVehicle = new HashSet<CustomerVehicle>();
        }

        public int Id { get; set; }
        public string Vin { get; set; }
        public string RegNr { get; set; }
        public bool IsConnected { get; set; }

        public virtual ICollection<CustomerVehicle> CustomerVehicle { get; set; }
    }
}