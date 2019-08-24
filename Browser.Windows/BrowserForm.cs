using H3ml.Layout;
using H3ml.Services;
using System;
using System.Windows.Forms;

namespace Browser.Windows
{
    public partial class _browser : Form
    {
        readonly context _context = new context();
        bool _consoleOpen = true;

        public _browser()
        {
            InitializeComponent();
        }

        public void create()
        {
            var css = Resources.master_css;
            _context.load_master_stylesheet(css);
            _view.create(_context);
            _toolbar.create();
            SetSize(840, 640);
        }

        void SetSize(int width, int height)
        {
            Width = width; Height = height;
            OnResize(null);
        }

        protected override void OnResize(EventArgs e)
        {
            _toolbar.Width = Width;
            _view.Width = Width;
            _console.Width = Width;
            _toolbar.Width = Width;
            _toolbar.Height = _toolbar.set_width(Width);
            _view.Top = _toolbar.Bottom;
            _view.Height = Height - _toolbar.Height - (!_consoleOpen ? 0 : _console.Height);
            _console.Visible = _consoleOpen;
            _console.Top = _view.Bottom;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F12:
                    _consoleOpen = !_consoleOpen;
                    OnResize(null);
                    break;
            }
            base.OnKeyDown(e);
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
            _console.on_page_loaded(url);
        }
    }
}
