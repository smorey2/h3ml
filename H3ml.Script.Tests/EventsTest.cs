﻿using NUnit.Framework;

namespace H3ml.Script
{
    public class EventsTest
    {
        [Test]
        public void EngineTest()
        {
            var engine = new ScriptEngine(null);
            engine.Test();
        }
    }
}
