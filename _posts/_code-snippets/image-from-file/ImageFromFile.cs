public static class Utils
{
  public static Image ImageFromFile(string filePath)
  {
    if (filePath == null) throw new ArgumentNullException("filePath");

    using(FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
    {
      return Image.FromStream(stream);
    }
  }
}