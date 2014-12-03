using System;
using System.Web;
 
namespace TC
{
  public static class GoogleAnalytics
  {
    public static string RenderScript(string googleAnalyticsID)
    {
      return string.IsNullOrEmpty(googleAnalyticsID)
        ? ""
        : "<script>"
        + "var _gaq=_gaq||[];"
        + "_gaq.push(['_setAccount','" + googleAnalyticsID + "']);"
        + "_gaq.push(['_trackPageview']);"
        + "(function(d,s){"
        + "var e=d.getElementsByTagName(s)[0],"
        + "x=d.createElement(s);"
        + "x.async=1;"
        + "x.src='"
        + (HttpContext.Current.Request.IsSecureConnection
            ? "https://ssl" : "http://www")
        + ".google-analytics.com/ga.js';"
        + "e.parentNode.insertBefore(x,e)}(document,'script'))</script>";
    }
  }
}