---
layout: post
title: "Years, months and days between 2 dates"
---

Here you can find a method that can calculate the years, months and days between 2 dates.

```csharp
/// <summary>Calculates the difference between 2 dates in years, months and days.</summary>
/// <param name="startDate">The start date.</param>
/// <param name="endDate">The end date.</param>
/// <param name="years">The variable that will contain the years.</param>
/// <param name="months">The variable that will contain the months.</param>
/// <param name="days">The variable that will contain the days.</param>
public static void DateDifference(
  DateTime startDate, DateTime endDate,
  out int years, out int months, out int days)
{
  years = endDate.Year - startDate.Year;
  months = endDate.Month - startDate.Month;
  days = endDate.Day - startDate.Day;

  if (days < 0)
  {
    months -= 1;
  }
  
  while (months < 0)
  {
    months += 12;
    years -= 1;
  }

  TimeSpan timeSpan = endDate - startDate.AddYears(years).AddMonths(months);
  days = (int)Math.Round(timeSpan.TotalDays);
}
```

And here is a method that uses the previous method and returns a string representation of the difference:

```csharp
/// <summary>Calculates the difference between 2 dates, and returns it as a formatted string.</summary>
/// <param name="startDate">The start date.</param>
/// <param name="endDate">The end date.</param>
/// <returns>The formatted string that represents the calculated difference.</returns>

public static string DateDifferenceToString(DateTime startDate, DateTime endDate)
{
  int years, months, days;
  DateDifference(startDate, endDate, out years, out months, out days);

  return 
    ((years != 0 ? years.ToString() + "y " : "") +
    (months != 0 ? months.ToString() + "m " : "") +
    (days != 0 ? days.ToString() + "d" : "")).TrimEnd();
}
```