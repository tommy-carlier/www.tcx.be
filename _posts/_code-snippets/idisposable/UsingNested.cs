using (var stream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
{
  using (var writer = new StreamWriter(stream, Encoding.UTF8))
  {
    foreach (string line in lines)
    {
      writer.WriteLine(line);
    }
  }
}