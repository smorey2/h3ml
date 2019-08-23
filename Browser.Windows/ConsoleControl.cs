using H3ml.Layout;
using H3ml.Layout.Containers;

namespace Browser.Forms
{
    public partial class ConsoleControl : container_form
    {
        context _context = new context();
        document _doc;
        //el_omnibox _omnibox;
        string _cursor;
        bool _inCapture;

        public ConsoleControl()
        {
            InitializeComponent();
            _context.load_master_stylesheet("html,div,body { display: block; } head,style { display: none; }");
        }
    }
}
