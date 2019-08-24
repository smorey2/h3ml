using System;
using System.IO;
using System.Net.Http;

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

        public HttpResponseMessage Get(string url)
        {
            try { return _client.GetAsync(url).Result; }
            catch { return null; }
        }

        public Stream GetStream(string url)
        {
            try { return _client.GetStreamAsync(url).Result; }
            catch { return null; }
        }

        public void GetPromise(string url, Action<HttpResponseMessage> success, Action<string> error)
        {
            var t = _client.GetAsync(url);
            t.Wait();
            if (t.IsCompleted) success(t.Result);
            else error(t.IsFaulted ? t.Exception.Message : "Error");
        }

        public void Stop() => _client.CancelPendingRequests();
    }
}