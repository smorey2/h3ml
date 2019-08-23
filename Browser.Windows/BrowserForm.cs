using H3ml.Layout;
using H3ml.Services;
using System;
using System.Windows.Forms;

namespace Browser.Forms
{
    public partial class BrowserForm : Form
    {
        readonly context _context = new context();
        bool _consoleOpen = true;

        public BrowserForm()
        {
            InitializeComponent();
            SetSize(840, 640);
            var css = Resources.master_css;
            _context.load_master_stylesheet(css);
            _view.Set(_context);
        }

        void SetSize(int width, int height)
        {
            Width = width; Height = height;
            BrowserForm_Resize(null, null);
        }

        void BrowserForm_Resize(object sender, EventArgs e)
        {
            _toolbar.Width = Width;
            _view.Width = Width;
            _console.Width = Width;
            //
            _view.Height = Height - _toolbar.Height - (!_consoleOpen ? 0 : _console.Height);
            _console.Top = _view.Bottom;
        }

        public void open(string path) => _view.open(path, true);
        public void back() => _view.back();
        public void forward() => _view.forward();
        public void reload() => _view.refresh();
        public void calc_time(int calc_repeat = 1) => _view.render(true, true, calc_repeat);
        public void on_page_loaded(string url)
        {
            _view.Focus();
            _toolbar.on_page_loaded(url);
            //_console.on_page_loaded(url);
        }
    }
}
