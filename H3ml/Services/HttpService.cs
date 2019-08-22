using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;

namespace H3ml.Services
{
    public class HttpService
    {
        readonly static HttpClient _client;
        string _url;

        static HttpService()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("User-Agent", "litebrowser/1.0");
            //_client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/74.0.3729.169 Safari/537.36");
        }

        public Stream load_file(string url)
        {
            if (url.IndexOf("://") == -1)
                url = "https://" + url;
            _url = url;
            try { return _client.GetStreamAsync(url).Result; }
            catch { return null; }
        }

        public string url => _url;

        //static size_t curlWriteFunction(void* ptr, size_t size, size_t nmemb, void* stream)
        //{
        //    Glib::RefPtr<Gio::MemoryInputStream>* s = (Glib::RefPtr<Gio::MemoryInputStream>*)stream;
        //    (*s)->add_data(ptr, size * nmemb);
        //    return size * nmemb;
        //}
    }
}