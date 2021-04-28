using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public static class RedrawWindow
{
    private const int WmPaint = 0x000F;

    [DllImport("User32.dll")]
    public static extern Int64 SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

    public static void ForcePaint(this Form form)
    {
        SendMessage(form.Handle, WmPaint, IntPtr.Zero, IntPtr.Zero);
    }
}
