using NUnit.Framework;

namespace H3ml.Script
{
    public class ScriptTest
    {
        [Test]
        public void DocumentTest()
        {
            var engine = new ScriptEngine(null);
            engine.Test();
        }
    }
}
