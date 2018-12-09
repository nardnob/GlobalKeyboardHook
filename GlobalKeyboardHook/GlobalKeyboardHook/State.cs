using System;
using System.Collections.Generic;

namespace GlobalKeyboardHook
{
    public class State
    {
        public Dictionary<int, Dictionary<int, int>> ClickedPoints = new Dictionary<int, Dictionary<int, int>>();

        public UInt64 ClickCount { get; set; }
        public UInt64 KeyCount { get; set; }

        public bool Loading { get; set; }
        public bool Hidden { get; set; }
    }
}
