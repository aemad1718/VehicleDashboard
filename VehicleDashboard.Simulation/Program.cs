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
            const int min = 1000;
            const int max = 9999;
            var rdm = new Random();

            using (var context = new VehicledashboardContext())
            {
                var vehicles = context.Vehicle.ToList();

                Parallel.ForEach(vehicles, t =>
                {
                    var pingValue = rdm.Next(min, max);
                    t.IsConnected = pingValue % 4 == 0;
                });

                context.SaveChanges();
            }
        }
    }
}
