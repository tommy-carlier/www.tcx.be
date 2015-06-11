using (var enumerator = collection.GetEnumerator())
{
  if (enumerator.MoveNext())
  {
    Before();

    do
    {
      var item = enumerator.Current;
      During();
    }
    while (enumerator.MoveNext());

    After();
  }
}