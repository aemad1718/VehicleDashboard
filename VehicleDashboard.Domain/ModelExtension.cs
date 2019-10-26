using System.Collections.Generic;
using VehicleDashboard.DatabaseRepositoryInterface;
using VehicleDashboard.DomainInterface.Models;

namespace VehicleDashboard.Domain
{
    internal static class ModelExtension
    {
        internal static VehicleModel ToVehicleModel(this Vehicle vehicle) => vehicle == null ? null : new VehicleModel
        {
            Vin = vehicle.Vin,
            Id = vehicle.Id,
            RegNr = vehicle.RegNr,
            IsConnected = vehicle.IsConnected
        };

        internal static List<VehicleModel> ToVehicleModels(this List<Vehicle> vehicles)
        {
            List<VehicleModel> vehicleModels = new List<VehicleModel>();

            if (vehicles != null)
            {
                vehicles.ForEach(v =>
                vehicleModels.Add(v.ToVehicleModel()));
            }

            return vehicleModels;
        }

        internal static CustomerModel ToCustomerModel(this Customer customer) => customer == null ? null : new CustomerModel
        {
            Id = customer.Id,
            FullName = customer.FullName
        };

        internal static List<CustomerModel> ToCustomerModels(this List<Customer> customers)
        {
            List<CustomerModel> customerModels = new List<CustomerModel>();

            if (customers != null)
            {
                customers.ForEach(c =>
                customerModels.Add(c.ToCustomerModel()));
            }

            return customerModels;
        }
    }
}
