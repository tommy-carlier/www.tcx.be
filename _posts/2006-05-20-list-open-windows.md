---
layout: post
title: Getting a list of all the open windows
---

Here’s some code you can use to get a list of all the open windows. Actually, you get a dictionary where each item is a `KeyValuePair` where the key is the handle (`hWnd`) of the window and the value is its title.

```csharp
using HWND = IntPtr;

/// <summary>Contains functionality to get all the open windows.</summary>
public static class OpenWindowGetter
{
  /// <summary>Returns a dictionary that contains the handle and title of all the open windows.</summary>
  /// <returns>A dictionary that contains the handle and title of all the open windows.</returns>
  public static IDictionary<HWND, string> GetOpenWindows()
  {
    HWND shellWindow = GetShellWindow();
    Dictionary<HWND, string> windows = new Dictionary<HWND, string>();

    EnumWindows(delegate(HWND hWnd, int lParam)
    {
      if (hWnd == shellWindow) return true;
      if (!IsWindowVisible(hWnd)) return true;

      int length = GetWindowTextLength(hWnd);
      if (length == 0) return true;

      StringBuilder builder = new StringBuilder(length);
      GetWindowText(hWnd, builder, length + 1);

      windows[hWnd] = builder.ToString();
      return true;

    }, 0);

    return windows;
  }

  delegate bool EnumWindowsProc(HWND hWnd, int lParam);

  [DllImport("USER32.DLL")]
  static extern bool EnumWindows(EnumWindowsProc enumFunc, int lParam);

  [DllImport("USER32.DLL")]
  static extern int GetWindowText(HWND hWnd, StringBuilder lpString, int nMaxCount);

  [DllImport("USER32.DLL")]
  static extern int GetWindowTextLength(HWND hWnd);

  [DllImport("USER32.DLL")]
  static extern bool IsWindowVisible(HWND hWnd);

  [DllImport("USER32.DLL")]
  static extern IntPtr GetShellWindow();
}
```

And here’s some code that uses it:

```csharp
foreach(KeyValuePair<IntPtr, string> window in OpenWindowGetter.GetOpenWindows())
{
  IntPtr handle = window.Key;
  string title = window.Value;

  Console.WriteLine("{0}: {1}", handle, title);
}
```