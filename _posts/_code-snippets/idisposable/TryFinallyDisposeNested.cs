var stream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
try
{
  var writer = new StreamWriter(stream, Encoding.UTF8);
  try
  {
    foreach (string line in lines)
    {
      writer.WriteLine(line);
    }
  }
  finally
  {
    writer.Dispose();
  }
}
finally
{
  stream.Dispose();
}