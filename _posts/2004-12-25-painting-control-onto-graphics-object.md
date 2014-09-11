---
layout: post
title: Painting a Control onto a Graphics-object
---

**Edit 2005-10-29: as of .NET 2.0, the `Control` class has a method to draw itself to a Bitmap: [DrawToBitmap](http://msdn2.microsoft.com/en-us/library/ms158401.aspx), which you should use instead.**

Here’s a little class in C#, that allows you to paint an existing Control onto a Graphics object. Nothing special, but useful if you need it.

```csharp
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
```

Using it is very easy: if you need to paint the Control *myControl* onto Graphics *myGraphics*, you just call `ControlPainter.PaintControl(myGraphics, myControl)`