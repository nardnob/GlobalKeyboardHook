using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GlobalKeyboardHook
{
    public static class Extensions
    {
        public static void UIThread(this Control control, Action code)
        {
            if (control.IsDisposed)
                return;

            if (control.InvokeRequired)
                control.BeginInvoke(code);
            else
                code();
        }

	    public static void AddItems<T>(this List<T> items, params T[] elements)
	    {
		    items.AddRange(elements);
	    }
    }
}
