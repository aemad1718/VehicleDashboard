using System.Collections.Generic;
using VehicleDashboard.DatabaseRepositoryInterface;
using VehicleDashboard.DomainInterface.Models;

namespace VehicleDashboard.Domain
{
    internal static class ModelExtension
    {
        private static VehicleModel ToVehicleModel(this Vehicle vehicle) => vehicle == null ? null : new VehicleModel
        {
            Vin = vehicle.Vin,
            Id = vehicle.Id,
            RegNr = vehicle.RegNr,
            IsConnected = vehicle.IsConnected
        };

        internal static List<VehicleModel> ToVehicleModels(this List<Vehicle> vehicles)
        {
            List<VehicleModel> vehicleModels = new List<VehicleModel>();

            vehicles?.ForEach(v =>
                vehicleModels.Add(v.ToVehicleModel()));

            return vehicleModels;
        }

        private static CustomerModel ToCustomerModel(this Customer customer) => customer == null ? null : new CustomerModel
        {
            Id = customer.Id,
            FullName = customer.FullName
        };

        internal static List<CustomerModel> ToCustomerModels(this List<Customer> customers)
        {
            List<CustomerModel> customerModels = new List<CustomerModel>();

            customers?.ForEach(c =>
                customerModels.Add(c.ToCustomerModel()));

            return customerModels;
        }
    }
}
