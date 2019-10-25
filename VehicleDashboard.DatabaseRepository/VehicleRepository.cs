using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleDashboard.DatabaseEntity;
using VehicleDashboard.DatabaseRepositoryInterface;

namespace VehicleDashboard.DatabaseRepository
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly IGenericRepository _genericRepository;

        public VehicleRepository(IGenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public List<Vehicle> GetAllVehicles()
        {
            return _genericRepository.GetList<Vehicle>();
        }

        public List<Vehicle> GetVehicles(bool? isConnected, int? customerId)
        {
            List<CustomerVehicle> customerVehicles = _genericRepository.GetList<CustomerVehicle>(cv =>
             (cv.Vehicle.IsConnected == isConnected || isConnected == null)
             && (cv.CustomerId == customerId || customerId == null), v => v.Vehicle).ToList();

            List<Vehicle> vehicles = new List<Vehicle>();

            customerVehicles.ForEach(cv => vehicles.Add(cv.Vehicle));

            return vehicles;
        }
    }
}
