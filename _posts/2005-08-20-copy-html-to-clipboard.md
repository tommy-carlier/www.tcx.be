---
layout: post
title: "Copying an HTML-fragment to the clipboard"
---

Applications like Word and Excel let you copy some text or tabular data to the clipboard in HTML-format, so that the formatting and visual style doesn’t change when pasted. At work, I had to do something similar: our application uses a lot of grid-controls to display data, and we wanted the users to be able to select data from a grid, and copy it to the clipboard, in a format that would keep the tabular structure of the data. After some research, I found out that you can copy data to the clipboard in HTML-format, and I thought: this is it. Piece of cake. But it wasn’t. Apparently, you have to pass a bit more information than just the HTML-code. Googling around gave me some hints how it should be done, but nothing really specific. So I started experimenting, until it worked correctly.

Tip: use a `StringBuilder` to build the HTML-code, instead of concatenating strings. StringBuilders are very efficient for building long strings (hence the name StringBuilder): they are a lot faster than strings, and allocate much less memory.

## Possible applications

There are a lot of situations where you could use this:

- Copying tabular data (and pasting it in Excel, Word or Outlook).
- Copying formatted, visually styled data.
- …

## The Code

```csharp
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

internal static class Test
{
  public static void CopyHtmlToClipBoard(string html)
  {
    Encoding enc = Encoding.UTF8;

    string begin = "Version:0.9\r\nStartHTML:{0:000000}\r\nEndHTML:{1:000000}"
      + "\r\nStartFragment:{2:000000}\r\nEndFragment:{3:000000}\r\n";

    string html_begin = "<html>\r\n<head>\r\n"
      + "<meta http-equiv=\"Content-Type\""
      + " content=\"text/html; charset=" + enc.WebName + "\">\r\n"
      + "<title>HTML clipboard</title>\r\n</head>\r\n<body>\r\n"
      + "<!--StartFragment-->";

    string html_end = "<!--EndFragment-->\r\n</body>\r\n</html>\r\n";

    string begin_sample = String.Format(begin, 0, 0, 0, 0);

    int count_begin = enc.GetByteCount(begin_sample);
    int count_html_begin = enc.GetByteCount(html_begin);
    int count_html = enc.GetByteCount(html);
    int count_html_end = enc.GetByteCount(html_end);

    string html_total = String.Format(
      begin
      , count_begin
      , count_begin + count_html_begin + count_html + count_html_end
      , count_begin + count_html_begin
      , count_begin + count_html_begin + count_html
      ) + html_begin + html + html_end;

    DataObject obj = new DataObject();
    obj.SetData(DataFormats.Html, new MemoryStream(
      enc.GetBytes(html_total)));
      
    Clipboard.SetDataObject(obj, true);
  }
}
```

## Example: copying a DataTable

```csharp
StringBuilder html = new StringBuilder();
html.Append("<table>");

foreach(DataRow row in table.Rows)
{
  html.Append("<tr>");
  foreach(object o in row)
  {
    html.AppendFormat("<td>{0}</td>", o);
  }
    
  html.Append("</tr>");
}

html.Append("</table>");
Test.CopyHtmlToClipboard(html.ToString());
```