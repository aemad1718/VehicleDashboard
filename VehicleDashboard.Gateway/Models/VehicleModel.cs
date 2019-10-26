namespace VehicleDashboard.Gateway.Models
{
    public class VehicleModel
    {
        public int Id { get; set; }

        public string Vin { get; set; }

        public string RegNr { get; set; }

        public bool IsConnected { get; set; }
    }
}
