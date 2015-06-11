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
Utilities.CopyHtmlToClipboard(html.ToString());