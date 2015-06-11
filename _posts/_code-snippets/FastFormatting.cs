public static string Format(
  object value,
  IFormatProvider formatProvider,
  string formatSpecifier)
{
  if (formatSpecifier.Length == 0)
  {
    return value.ToString();
  }

  if (formatProvider == null)
  {
    formatProvider = CultureInfo.CurrentCulture;
  }

  ICustomFormatter formatter = formatProvider.GetFormat(
    typeof(ICustomFormatter)) as ICustomFormatter;

  if (formatter != null)
  {
    return formatter.Format(formatSpecifier, value, formatProvider);
  }

  IFormattable formattable = value as IFormattable;
  if (formattable != null)
  {
    return formattable.ToString(formatSpecifier, formatProvider);
  }

  return value.ToString();
}