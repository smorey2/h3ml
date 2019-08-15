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
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var html_context = new context();
            html_context.load_master_stylesheet(Resources.master_css);

            Application.Run(new BrowserForm(html_context));
        }
    }
}
