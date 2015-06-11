using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public class ControlPainter
{
  private const int
    WM_PRINT = 0x317, PRF_CLIENT = 4,
    PRF_CHILDREN = 0x10, PRF_NON_CLIENT = 2,
    COMBINED_PRINTFLAGS = PRF_CLIENT | PRF_CHILDREN | PRF_NON_CLIENT;

  [DllImport("USER32.DLL")]
  private static extern int SendMessage(
    IntPtr hWnd, int Msg, IntPtr wParam, int lParam);

  public static void PaintControl(Graphics graphics, Control control)
  {
    // paint control onto graphics
    IntPtr hWnd = control.Handle;
    IntPtr hDC = graphics.GetHdc();
    SendMessage(hWnd, WM_PRINT, hDC, COMBINED_PRINTFLAGS);
    graphics.ReleaseHdc(hDC);
  }
}