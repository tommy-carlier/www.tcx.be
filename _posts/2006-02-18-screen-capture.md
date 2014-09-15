---
layout: post
title: Capturing a screen region to the clipboard
---

While writing a little screen capture tool (which you can [download from Box](https://app.box.com/s/4lwepaw898f5ir3bv1dy)), I used to following code to capture a region on the screen and copy it to the clipboard:

```csharp
Rectangle region = …; // the screen region to capture

using (Bitmap bitmap = new Bitmap(
  region.Width, region.Height, PixelFormat.Format32bppArgb))
using (Graphics graphics = Graphics.FromImage(bitmap))
{
    graphics.CopyFromScreen(region.Left, region.Top, 0, 0, region.Size);
    Clipboard.SetImage(bitmap);
}
```