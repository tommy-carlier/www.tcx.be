public static class DataReaderExtensions
{
  public static void ReadAll(
    this IDataReader reader,
    Action before,
    Action<IDataRecord> during,
    Action after)
  {
    if (reader == null) throw new ArgumentNullException("reader");

    if (reader.Read())
    {
      if (before != null)
      {
        before();
      }
      
      do
      {
        if (during != null)
        {
          during(reader);
        }
      }
      while (reader.Read());
      
      if (after != null)
      {
        after();
      }
    }
  }
}