﻿using System;
using System.Collections.Generic;

namespace VehicleDashboard.Simulation
{
    public partial class CustomerVehicle
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int VehicleId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}