---
layout: post
title: "Formatting a file size"
---

Here’s a method that creates a human-readable string of a file-size:

```csharp
/// <summary>Returns a file size as a formatted string with a unit.</summary>
/// <param name="fileSize">The file size to format.</param>
/// <returns>The formatted string.</returns>
public static string FormatFileSize(long fileSize)
{
  if (fileSize < 0) throw new ArgumentOutOfRangeException("fileSize");

  if (fileSize >= 1024 * 1024 * 1024)
  {
    return string.Format("{0:########0.00} GB", ((double)fileSize) / (1024 * 1024 * 1024));
  }
  else if (fileSize >= 1024 * 1024)
  {
    return string.Format("{0:####0.00} MB", ((double)fileSize) / (1024 * 1024));
  }
  else if (fileSize >= 1024)
  {
    return string.Format("{0:####0.00} KB", ((double)fileSize) / 1024);
  }
  else
  {
    return string.Format("{0} bytes", fileSize);
  }
}
```