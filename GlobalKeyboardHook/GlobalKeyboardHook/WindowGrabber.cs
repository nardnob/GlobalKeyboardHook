using System;
using System.Runtime.InteropServices;

namespace GlobalKeyboardHook
{
    /// <summary>
    /// simple Windows API wrapper class that lets you drag the entire
    /// window during a MouseDown event of any control in a Form
    /// </summary>
    /// <example>
    ///   <code>
    ///     public partial class Form1 : Form
    ///     {
    ///         public Form1()
    ///         {
    ///             InitializeComponent();
    ///         }
    ///     
    ///         //you can grab the window during any MouseDown event
    ///         private void toolStrip1_MouseDown(object sender, MouseEventArgs e)
    ///         {
    ///             if (e.Button == MouseButtons.Left)
    ///             {
    ///                 GrabWindow();
    ///             }
    ///         }
    ///     
    ///         private void GrabWindow()
    ///         {
    ///             WindowGrabber.Grab(this.Handle);
    ///         }
    ///     }
    ///   </code>
    /// </example>
    public static class WindowGrabber
    {
        [DllImport("User32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("User32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        /// <summary>
        /// Calling this method "grips" the window while the mouse button is held.
        /// </summary>
        public static void Grab(IntPtr windowHandle)
        {
            //WM_NCLBUTTONDOWN in Windows API
            const int buttonDownMessage = 0xA1;

            //HTCAPTION in Windows API
            const int titleBar = 0x2;

            ReleaseCapture();
            SendMessage(windowHandle, buttonDownMessage, titleBar, 0);
        }
    }
}
