public class MyDerivedDisposableType : MyDisposableType
{
  protected override void Dispose(bool disposing)
  {
    try
    {
      if (disposing)
      {
        // clean up managed resources:
        // dispose child objects that implement IDisposable
      }
 
      // clean up unmanaged resources
    }
    finally
    {
      // always call the base-method!
      base.Dispose(disposing);
    }
  }
}