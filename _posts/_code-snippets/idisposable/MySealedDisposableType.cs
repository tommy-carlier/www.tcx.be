public sealed class MySealedDisposableType : IDisposable
{
  ~MySealedDisposableType()
  {
    // the finalizer also has to release unmanaged resources,
    // in case the developer forgot to dispose the object.
    Dispose(false);
  }
 
  public void Dispose()
  {
    Dispose(true);
 
    // this tells the garbage collector not to execute the finalizer
    GC.SuppressFinalize(this);
  }
 
  private void Dispose(bool disposing)
  {
    if (disposing)
    {
      // clean up managed resources:
      // dispose child objects that implement IDisposable
    }
 
    // clean up unmanaged resources
  }
}