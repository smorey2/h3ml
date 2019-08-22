using H3ml.Services;
using NUnit.Framework;

namespace H3ml.Layout
{
    public class ContextTest
    {
        [Test]
        public void Test()
        {
            var ctx = new context();
            ctx.load_master_stylesheet(Resources.master_css);
        }
    }
}
