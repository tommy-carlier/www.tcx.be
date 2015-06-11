public static string FilterNumbers(string mightContainNumbers)
{
  if (mightContainNumbers == null || mightContainNumbers.Length == 0)
  {
    return "";
  }

  StringBuilder builder = new StringBuilder(mightContainNumbers.Length);
  foreach (char c in mightContainNumbers)
  {
    if (Char.IsNumber(c))
    {
      builder.Append(c);
    }
  }

  return builder.ToString();
}