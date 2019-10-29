namespace VehicleDashboard.Gateway.Models
{
    /// <summary>
    /// View model to present the customers data.
    /// </summary>
    public class CustomerModel
    {
        /// <summary>
        /// Unique identified for the customer.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The full name of the customer.
        /// </summary>
        public string FullName { get; set; }
    }
}
