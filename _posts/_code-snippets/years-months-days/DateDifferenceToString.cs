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