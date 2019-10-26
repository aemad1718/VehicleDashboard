using System.Collections.Generic;
using System.Threading.Tasks;

namespace VehicleDashboard.CrossCutting
{
    public interface IHttpClientUtility
    {
        Task<T> Get<T>(string endpointUrl, Dictionary<string, object> parameters = null)
            where T : class, new();
    }
}
