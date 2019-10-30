namespace VehicleDashboard.Gateway.Models
{
    /// <summary>
    /// View model to present the vehicles data.
    /// </summary>
    public class VehicleModel
    {
        /// <summary>
        /// Vehicle uniquer identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Vehicle unique code.
        /// </summary>
        public string Vin { get; set; }

        /// <summary>
        /// Registration number.
        /// </summary>
        public string RegNr { get; set; }

        /// <summary>
        /// Vehicle connectivity status. true --> connected and false --> not connected.
        /// </summary>
        public bool IsConnected { get; set; }
    }
}
