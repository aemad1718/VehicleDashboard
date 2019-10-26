using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace VehicleDashboard.Gateway
{
    public class HttpClientUtility : IHttpClientUtility
    {
        public async Task<T> Get<T>(string endpointUrl, Dictionary<string, object> parameters = null)
            where T : class, new()
        {
            StringBuilder endpoingUrlBuilder = new StringBuilder(endpointUrl);

            if (parameters != null && parameters.Count > 0)
            {
                foreach (var item in parameters)
                {
                    if (parameters.ElementAt(0).Key == item.Key)
                    {
                        endpoingUrlBuilder.Append($"?{item.Key}={item.Value}");
                    }
                    else
                    {
                        endpoingUrlBuilder.Append($"&{item.Key}={item.Value}");
                    }
                }
            }

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(endpoingUrlBuilder.ToString()))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();

                        return !string.IsNullOrWhiteSpace(data) ? JsonConvert.DeserializeObject<T>(data) : new T();
                    }
                }
            }
        }
    }
}

