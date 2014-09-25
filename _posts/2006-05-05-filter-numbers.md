---
layout: post
title: Filtering numbers out of a string
---

Here’s a method that filters the numbers out of a string:

```csharp
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
```