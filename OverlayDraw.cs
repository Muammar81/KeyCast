using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace KeyCast
{
    class OverlayDraw : Form
    {

        [DllImport("User32.dll")]
        public static extern IntPtr GetDC(IntPtr hwnd);

        [DllImport("User32.dll")]
        public static extern void ReleaseDC(IntPtr dc);

        protected override void OnPaint(PaintEventArgs e)
        {
            IntPtr desktopDC = GetDC(IntPtr.Zero);

            Graphics g = Graphics.FromHdc(desktopDC);


/*            Brush shadowBrush = new SolidBrush(Color.Black); // <-- Here
            g.DrawString(text, font, shadowBrush, x + shadowOffset.Width, y + shadowOffset.Height); // <-- Here*/

            g.DrawString("Test", new Font(FontFamily.GenericSerif, 12), Brushes.Blue, 300, 300);
            
            g.Dispose();

            ReleaseDC(desktopDC);
        }
    }
}
