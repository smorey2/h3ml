using H3ml.Layout;
using H3ml.Layout.Containers;
using H3ml.Services;
using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;

namespace Browser.Forms
{
    public partial class WebpageControl : container_form
    {
        internal HttpService _http = new HttpService();
        internal string _url;
        internal document _doc;
        internal string _caption;
        internal string _cursor;
        string _base_url;
        string _waited_file;
        internal string _hash;

        public WebpageControl()
        {
            InitializeComponent();
        }

        public override void set_caption(string caption) => _caption = caption;

        public override void set_base_url(string base_url)
        {
            if (base_url != null)
            {
                if (!Path.IsPathRooted(base_url) && !Uri.IsWellFormedUriString(base_url, UriKind.RelativeOrAbsolute))
                    make_url(base_url, _url, out _base_url);
                else
                    _base_url = base_url;
            }
            else
                _base_url = _url;
        }

        protected override void make_url(string url, string basepath, out string urlout) => urlout = string.IsNullOrEmpty(basepath) ? !string.IsNullOrEmpty(_base_url) ? urljoin(_base_url, url) : url : urljoin(basepath, url);

        public override void import_css(out string text, string url, ref string baseurl)
        {
            text = null;
            make_url(url, baseurl, out var css_url);
            if (download_and_wait(css_url))
            {
                var css = load_text_file(css_url, false, "UTF-8");
                if (css != null)
                {
                    baseurl = css_url;
                    text = css;
                }
            }
        }

        public override void on_anchor_click(string url, element el)
        {
            make_url(url, null, out var anchor);
            ((HtmlControl)Parent).open(anchor);
        }

        public override void set_cursor(string cursor) => _cursor = cursor;

        object get_image(string url, bool redraw_on_ready = false)
        {
            if (Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute))
            {
                _http.GetAsync(url)
                      .ContinueWith(t => on_document_error(t.IsFaulted ? t.Exception.Message : "Error"), TaskContinuationOptions.NotOnRanToCompletion)
                      .ContinueWith(t => on_image_loaded(null, url, redraw_on_ready), TaskContinuationOptions.OnlyOnRanToCompletion)
                      .Wait();
                return null;
            }
            else
                using (var s = _http.Get(url))
                    try { return s != null ? Image.FromStream(s) : null; }
                    catch { return null; }
        }

        public void load(string url)
        {
            _url = url;
            _base_url = url;
            if (Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute))
            {
                _http.GetAsync(url)
                    .ContinueWith(t => on_document_loaded(t.Result.Content.ReadAsStreamAsync().Result, "UTF-8", t.Result.Headers?.Location.ToString()), TaskContinuationOptions.OnlyOnRanToCompletion)
                    .ContinueWith(t => on_document_error(t.IsFaulted ? t.Exception.Message : "Error"), TaskContinuationOptions.NotOnRanToCompletion)
                    .Wait();
                return;
            }
            else
                using (var file = _http.Get(url))
                    on_document_loaded(file, "UTF-8", null);
        }

        void on_document_loaded(Stream file, string encoding, string realUrl)
        {
            if (realUrl != null)
                _url = realUrl;
            var html_text = load_utf8_file(file, true);
            if (html_text == null)
                html_text = "<h1>Something Wrong</h1>";
            _doc = document.createFromUTF8(html_text, this, ((HtmlControl)Parent).get_html_context());
            //PostMessage(m_parent->wnd(), WM_PAGE_LOADED, 0, 0);
        }

        string load_text_file(string url, bool is_html, string defEncoding = "UTF-8")
        {
            using (var file = _http.Get(url))
            {
                var utf8 = load_utf8_file(file, is_html, defEncoding);
                return utf8 != null ? utf8 : null;
            }
        }

        void on_document_error(string errMsg)
        {
            var txt = "<h1>Something Wrong</h1>";
            if (errMsg != null)
            {
                txt += "<p>";
                txt += errMsg;
                txt += "</p>";
            }
            _doc = document.createFromString(txt, this, ((HtmlControl)Parent).get_html_context());
            //PostMessage(m_parent->wnd(), WM_PAGE_LOADED, 0, 0);
        }

        void on_image_loaded(Stream file, string url, bool redraw_only)
        {
            try
            {
                var img = Image.FromStream(file);
                //cairo_container::add_image(std::wstring(url), img);
                //if (_doc != null)
                //    PostMessage(m_parent->wnd(), WM_IMAGE_LOADED, (WPARAM)(redraw_only ? 1 : 0), 0);
            }
            catch { }
        }

        bool download_and_wait(string url)
        {
            if (Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute))
            {
                _waited_file = string.Empty;
                _http.GetAsync(url)
                    .ContinueWith(t => on_waited_finished(null, url), TaskContinuationOptions.OnlyOnRanToCompletion)
                    .ContinueWith(t => on_waited_finished(t.Exception?.Message, url), TaskContinuationOptions.NotOnRanToCompletion)
                    .Wait();
                return !string.IsNullOrEmpty(_waited_file);
            }
            else
            {
                _waited_file = url;
                return true;
            }
        }

        void on_waited_finished(string dwError, string file)
        {
            _waited_file = dwError != null ? "" : file;
        }

        public override void get_client_rect(out position client) => ((HtmlControl)Parent).get_client_rect(out client);

        public void get_url(out string url)
        {
            url = _url;
            if (!string.IsNullOrEmpty(_hash))
            {
                url += "#";
                url += _hash;
            }
        }

        string load_utf8_file(Stream file, bool is_html, string defEncoding = "UTF-8")
        {
            using (var r = new StreamReader(file))
                return r.ReadToEnd();
        }
    }
}
