using System.Diagnostics;

namespace H3ml.Layout
{
    public class context
    {
        public void load_master_stylesheet(string str)
        {
            master_css.parse_stylesheet(str, null, null, null);
            master_css.sort_selectors();
        }

        public css master_css { get; } = new css();

        //public static int PrintIndent = -1;
        //public static void PrintLine(string text)
        //{
        //    Debug.Write(new string(' ', PrintIndent * 2)); Debug.WriteLine(text);
        //}
    }
}
