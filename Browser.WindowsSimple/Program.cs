using H3ml.Layout;
using H3ml.Services;
using System;
using System.Windows.Forms;

namespace Browser.Forms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var ctx = new context();
            ctx.load_master_stylesheet(Resources.master_css);

            var frm = new BrowserForm(ctx);
            frm.open(args?.Length != 0 ? args[0] : "http://www.litehtml.com/");
            Application.Run(frm);
        }
    }
}
