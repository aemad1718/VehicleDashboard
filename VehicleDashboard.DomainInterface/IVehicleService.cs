using System.Collections.Generic;
using VehicleDashboard.DomainInterface.Models;

namespace VehicleDashboard.DomainInterface
{
    public interface IVehicleService
    {
        List<VehicleModel> GetAllVehicles();

        List<VehicleModel> GetVehicles(bool? isConnected, int? customerId);
    }
}
