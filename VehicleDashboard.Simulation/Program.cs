using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleDashboard.Simulation
{
    public static class Program
    {
        static void Main(string[] args)
        {
            SimulatePingVehicle();
        }

        private static void SimulatePingVehicle()
        {
            int min = 1000;
            int max = 9999;
            Random rdm = new Random();

            using (VehicledashboardContext context = new VehicledashboardContext())
            {
                List<Vehicle> vehicles = context.Vehicle.ToList();

                Parallel.ForEach(vehicles, t =>
                {
                    int pingValue = rdm.Next(min, max);
                    t.IsConnected = pingValue % 4 == 0;
                });

                context.SaveChanges();
            }
        }
    }
}
