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