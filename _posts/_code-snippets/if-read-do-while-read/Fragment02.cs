using (IDataReader reader = command.ExecuteReader())
{
  if (reader.Read())
  {
    Before();

    do
    {
      During();
    }
    while (reader.Read());

    After();
  }
}