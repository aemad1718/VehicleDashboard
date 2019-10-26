using System.Collections.Generic;
using System.Threading.Tasks;

namespace VehicleDashboard.Gateway
{
    public interface IHttpClientUtility
    {
        Task<T> Get<T>(string endpointUrl, Dictionary<string, object> parameters = null)
            where T : class, new();
    }
}
