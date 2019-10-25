using System.Collections.Generic;
using System.Linq;
using VehicleDashboard.DatabaseEntity;
using VehicleDashboard.DatabaseRepositoryInterface;
using VehicleDashboard.DomainInterface;
using VehicleDashboard.DomainInterface.Models;

namespace VehicleDashboard.Domain
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public List<VehicleModel> GetAllVehicles()
        {
            return _vehicleRepository.GetAllVehicles().ToVehicleModels();
        }

        public List<VehicleModel> GetVehicles(bool? isConnected, int? customerId)
        {
            return _vehicleRepository.GetVehicles(isConnected, customerId).ToVehicleModels();
        }
    }
}
