using System;
using System.Collections.Generic;

namespace VehicleDashboard.Simulation
{
    public partial class CustomerAddress
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Address { get; set; }

        public virtual Customer Customer { get; set; }
    }
}