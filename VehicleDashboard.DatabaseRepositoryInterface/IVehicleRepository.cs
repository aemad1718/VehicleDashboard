using System.Collections.Generic;
using VehicleDashboard.DatabaseEntity;

namespace VehicleDashboard.DatabaseRepositoryInterface
{
    public interface IVehicleRepository
    {
        List<Vehicle> GetAllVehicles();

        List<Vehicle> GetVehicles(bool? isConnected, int? customerId);
    }
}
