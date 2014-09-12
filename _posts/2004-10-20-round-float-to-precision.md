---
layout: post
title: Rounding a floating point value to a certain precision
---

For my work, I needed to round a floating point value (`double` in C#) to a precision of 0.05. Unfortunately, `Math.Round` only lets you round a value to the nearest decimal. That means you can only round to 0.1, 0.01, 0.001, … To round your values to 0.05, or 0.25, or whatever, I created the following function:

```csharp
public static double Round(double x, int numerator, int denominator)
{
  // returns the number nearest x, with a precision of numerator/denominator
  // example: Round(12.1436, 5, 100) ⇒ 12.15 (precision = 5/100 = 0.05)
  
  long y = (long)Math.Floor(x * denominator + (double)numerator / 2.0);
  return (double)(y - y % numerator)/(double)denominator;
}
```