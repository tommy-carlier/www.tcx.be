StringBuilder html = new StringBuilder();
using (IDataReader reader = command.ExecuteReader())
{
  reader.ReadAll(
    () => html.Append("<ul>"),
    record => html.AppendFormat("<li>{0}", record.GetValue(0)),
    () => html.Append("</ul>"));
}