using H3ml.Script;
using H3ml.Script.Events;
using System;
using System.Collections.Generic;

namespace H3ml.Layout
{
    partial class node
    {
        void dispatchEvent(Event event_)
        {
            EventDispatcher.dispatchEvent(this, event_);
        }
    }
}
