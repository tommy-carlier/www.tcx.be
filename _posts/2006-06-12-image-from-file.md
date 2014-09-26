---
layout: post
title: "Reading an image from a file without locking it (GDI+)"
---

When you use `System.Drawing.Image.FromFile` to read an image from a file, the file is locked. The following method reads an image from a file without locking it:

```csharp
public static class Utils
{
  public static Image ImageFromFile(string filePath)
  {
    if (filePath == null) throw new ArgumentNullException("filePath");

    using(FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
    {
      return Image.FromStream(stream);
    }
  }
}
```

Here’s an example how to use it:

```csharp
// old method that locks the file:
Image img = Image.FromFile("picture.jpg");

// new method that does not lock the file:
Image img = Utils.ImageFromFile("picture.jpg");
```