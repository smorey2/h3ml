using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace H3ml.Services
{
    public class HttpService
    {
        readonly static HttpClient _client = ConfigureHttpClient(new HttpClient());

        static HttpClient ConfigureHttpClient(HttpClient client)
        {
            var useragent = "litebrowser/1.0";
            //var useragent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/74.0.3729.169 Safari/537.36";
            client.DefaultRequestHeaders.Add("User-Agent", useragent);
            return client;
        }

        public Stream Get(string url)
        {
            Url = url;
            try { return _client.GetStreamAsync(url).Result; }
            catch { return null; }
        }

        public string Url { get; private set; }

        public Task<HttpResponseMessage> GetAsync(string url)
        {
            Url = url;
            return _client.GetAsync(new Uri(url));
        }

        public void Stop() => _client.CancelPendingRequests();
    }
}