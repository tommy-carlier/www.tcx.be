StringBuilder html = new StringBuilder();
using (IDataReader reader = command.ExecuteReader())
{
  if (reader.Read())
  {
    html.Append("<ul>");

    do
    {
      html.AppendFormat(
        "<li>{0}",
        reader.GetValue(0));
    }
    while (reader.Read());

    html.Append("</ul>");
  }
}