using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Bt.IPay.Net.Internal
{
    public class FormDataHttpClient : HttpClient
    {
        public FormDataHttpClient():base(new HttpClientHandler
        {
            DefaultProxyCredentials = CredentialCache.DefaultCredentials,
            Proxy = WebRequest.DefaultWebProxy
        })
        {
        }

        public async Task<T> GetAsync<T>(string uri)
        {
            var response = await GetStringAsync(new Uri(uri));
            return !response.Contains("error")
                ? JsonConverter.DeserializeObject<T>(response)
                : default;
        }

        public async Task<IEnumerable<T>> GetListAsync<T>(string uri)
        {
            var response = await GetStringAsync(new Uri(uri));
            return !response.Contains("error")
                ? JsonConverter.DeserializeObject<List<T>>(response)
                : Enumerable.Empty<T>();
        }

        public async Task<TR> PostAsync<T, TR>(string uri, T data)
        {
            var json = JsonConverter.SerializeObject(data);
            var values = JsonConverter.DeserializeObject<Dictionary<string, string>>(json);
            var formContent = new FormUrlEncodedContent(values.Where(fd=>!string.IsNullOrWhiteSpace(fd.Value)));

            var response = await PostAsync(new Uri(uri), formContent);
            if (!response.IsSuccessStatusCode) throw new HttpRequestException(response.StatusCode.ToString());

            var result = await response.Content.ReadAsStringAsync();

            var output = JsonConverter.DeserializeObject<TR>(result);
            return output;
        }
    }
}
