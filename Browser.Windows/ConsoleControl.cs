using H3ml.Layout;
using H3ml.Layout.Containers;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Browser.Windows
{
    public partial class ConsoleControl : container_form
    {
        readonly context _context = new context();
        document _doc;
        string _cursor;

        public ConsoleControl()
        {
            InitializeComponent();
        }

        void render_console(int width)
        {
            if (_doc == null)
                return;
            _doc.render(width);
        }

        void update_cursor()
        {
            var defArrow = Cursors.Arrow; //Cursors.Default
            if (_cursor == "pointer") Cursor = Cursors.Hand;
            else if (_cursor == "text") Cursor = Cursors.IBeam;
            else Cursor = defArrow;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (var cr = CreateGraphics())
            {
                var rect = cr.VisibleClipBounds;
                var clip = new position
                {
                    x = (int)rect.X,
                    y = (int)rect.Y,
                    width = (int)rect.Width,
                    height = (int)rect.Height,
                };
                if (_doc != null)
                    _doc.draw(cr, 0, 0, 0, clip);
            }
        }

        public void create()
        {
            _context.load_master_stylesheet("html,div,body { display: block; } head,style { display: none; }");
            string html;
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Browser.Windows.console.console.html"))
            using (var reader = new StreamReader(stream))
                html = reader.ReadToEnd();
            _doc = document.createFromString(html, this, _context);
            render_console(Width);
        }

        protected override object get_image(string url)
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"Browser.Windows.console.{url}"))
                return Image.FromStream(stream);
        }

        public int set_width(int width)
        {
            if (_doc == null)
                return 0;
            render_console(width);
            return _doc.height;
        }

        public void on_page_loaded(string url)
        {
        }

        public override void set_cursor(string cursor) => _cursor = cursor;

        public override void get_client_rect(out position client) => client = new position
        {
            x = Left,
            y = Top,
            width = Width,
            height = Height,
        };

        void Splitter_SplitterMoving(object sender, SplitterEventArgs e)
        {
            Height = e.SplitY;
        }
    }
}
