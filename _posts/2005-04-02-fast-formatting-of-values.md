---
layout: post
title: "Fast formatting of values in .NET"
---

I see people use `string.Format(formatProvider, "{0}", value)` or `string.Format(formatProvider, "{0:formatSpecifier}", value)`, just to format a single value (int, double, …). I used to do this too, until I looked at how `string.Format` works (using [Reflector](http://www.red-gate.com/products/dotnet-development/reflector/)). Apparently, a `StringBuilder`-object is created, and the `"{0:…}"` is parsed, a lot of appending happens and finally the `stringBuilder.ToString()` is returned. Here’s a function that does the same. Basically, it just does the same as inside `StringBuilder.AppendFormat`, but without all the parsing, creating and appending. It’s faster, and creates less temporary objects.

```csharp
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
```