using Microsoft.ClearScript;
using Microsoft.ClearScript.V8;
using System;
using System.IO;
using System.Reflection;

namespace H3ml.Script
{
    public class ScriptEngine
    {
        V8ScriptEngine _v8 = new V8ScriptEngine();

        public ScriptEngine()
        {
            _v8.AddHostObject("mscorlib", new HostTypeCollection("mscorlib"));
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("H3ml.Script.init.js"))
            using (var reader = new StreamReader(stream))
                _v8.Evaluate(reader.ReadToEnd());
        }

        public void LoadFile(string inputFile) => _v8.Evaluate(File.ReadAllText(inputFile));

        public void Evaluate(string line)
        {
            try { _v8.Evaluate(line); }
            catch (Exception e) { Console.Error.WriteLine(e.Message); }
        }

        public void Test()
        {
            _v8.Execute("function foo(s) { /* Some JavaScript Code Here */ return s; }");
        }
    }
}
