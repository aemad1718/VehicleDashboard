using System;
using System.Collections.Generic;
using System.Text;
using VehicleDashboard.DomainInterface.Models;

namespace VehicleDashboard.DomainInterface
{
    public interface IVehicleService
    {
        List<VehicleModel> GetAllVehicles();

        List<VehicleModel> GetVehicles(bool? isConnected, int? customerId);
    }
}
