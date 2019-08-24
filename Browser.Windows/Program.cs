using H3ml.Layout;
using H3ml.Services;
using System;
using System.Windows.Forms;

namespace Browser.Windows
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

            var frm = new _browser(); frm.create();
            frm.open(args?.Length != 0 ? args[0] : "http://www.litehtml.com/");
            Application.Run(frm);
        }
    }
}
