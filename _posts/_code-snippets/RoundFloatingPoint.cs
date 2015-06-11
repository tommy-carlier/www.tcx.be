public static double Round(double x, int numerator, int denominator)
{
  // returns the number nearest x, with a precision of numerator/denominator
  // example: Round(12.1436, 5, 100) ⇒ 12.15 (precision = 5/100 = 0.05)
  
  long y = (long)Math.Floor(x * denominator + (double)numerator / 2.0);
  return (double)(y - y % numerator)/(double)denominator;
}