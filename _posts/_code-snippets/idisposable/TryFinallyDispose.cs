var x = new X(); // X is a class that implements IDisposable
try
{
  // do something with x
}
finally
{
  x.Dispose();
}