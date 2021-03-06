using System;
using System.Globalization;
using System.Text;
 
namespace TC
{
  // Removes diacritics from a string
  //
  // Original version by Michael Kaplan: 
  // → http://blogs.msdn.com/b/michkap/archive/2007/05/14/2629747.aspx
  //
  // Optimized version by Tommy Carlier:
  // → http://www.tcx.be/blog/2011/remove-diacritics/
  public static class DiacriticsRemover
  {
    public static string RemoveDiacritics(this string text)
    {
      if (text == null) throw new ArgumentNullException("text");
 
      if (text.Length > 0)
      {
        char[] chars = new char[text.Length];
        int charIndex = 0;
 
        text = text.Normalize(NormalizationForm.FormD);
        for (int i = 0; i < text.Length; i++)
        {
          char c = text[i];
          if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
          {
            chars[charIndex++] = c;
          }
        }
 
        return new string(chars, 0, charIndex).Normalize(NormalizationForm.FormC);
      }
 
      return text;
    }
  }
}