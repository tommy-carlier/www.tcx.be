using (IDataReader reader = command.ExecuteReader())
{
  bool hasRows = false;
  while (reader.Read())
  {
    if (!hasRows)
    {
      hasRows = true;
      Before();
    }

    During();
  }

  if (hasRows)
  {
    After();
  }
}