using System.Diagnostics;

namespace H3ml.Layout
{
    [DebuggerDisplay("<script />")]
    public class el_script : element
    {
        string _text;

        public el_script(document doc) : base(doc) { }

        public override void parse_attributes()
        {
            //TODO: pass script text to document container
        }

        public override bool appendChild(element el) { el.get_text(ref _text); return true; }

        public override string get_tagName() => "script";
    }
}
