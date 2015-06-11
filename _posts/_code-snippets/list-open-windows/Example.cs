foreach(KeyValuePair<IntPtr, string> window in OpenWindowGetter.GetOpenWindows())
{
  IntPtr handle = window.Key;
  string title = window.Value;

  Console.WriteLine("{0}: {1}", handle, title);
}