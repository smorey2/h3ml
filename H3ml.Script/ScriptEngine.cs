using Microsoft.ClearScript.V8;
using System;
using System.IO;
using System.Reflection;

namespace H3ml.Script
{
    public class ScriptEngine : Iscript
    {
        readonly V8ScriptEngine _v8 = new V8ScriptEngine();
        readonly IWindow _window;

        public ScriptEngine(IWindow window)
        {
            _window = window;
            //_v8.AddHostObject("mscorlib", new HostTypeCollection("mscorlib"));
            _v8.AddHostObject("window", _window);
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("H3ml.Script.init.js"))
            using (var reader = new StreamReader(stream))
                _v8.Evaluate(reader.ReadToEnd());
        }

        public void LoadFile(string inputFile) => _v8.Evaluate(File.ReadAllText(inputFile));

        public void execute(IDocument doc, string line)
        {
            try { _v8.Evaluate(line); }
            catch (Exception e) { _window.console.error(e.Message); }
        }

        public void Test()
        {
            _v8.Execute("function foo(s) { /* Some JavaScript Code Here */ return s; }");
        }

    }
}
