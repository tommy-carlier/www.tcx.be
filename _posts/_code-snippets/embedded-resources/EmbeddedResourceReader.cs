/// <summary>Contains some methods to read data from an embedded resource.</summary>
public static class EmbeddedResourceReader
{
  /// <summary>Returns an embedded resource of the specified assembly as a string.</summary>
  /// <param name="assembly">The assembly to read the resource from.</param>
  /// <param name="resourceName">The name of the resource.</param>
  /// <returns>A string read from an embedded resource.</returns>
  public static string ReadString(Assembly assembly, string resourceName)
  {
    if (assembly == null) throw new ArgumentNullException("assembly");
    if (resourceName == null) throw new ArgumentNullException("resourceName");

    using(Stream stream = assembly.GetManifestResourceStream(resourceName))
    using(StreamReader reader = new StreamReader(stream))
    {
      return reader.ReadToEnd();
    }
  }

  /// <summary>Returns an embedded resource of the specified assembly as an icon.</summary>
  /// <param name="assembly">The assembly to read the resource from.</param>
  /// <param name="resourceName">The name of the resource.</param>
  /// <returns>An icon read from an embedded resource.</returns>
  public static Icon ReadIcon(Assembly assembly, string resourceName)
  {
    if (assembly == null) throw new ArgumentNullException("assembly");
    if (resourceName == null) throw new ArgumentNullException("resourceName");

    using(Stream stream = assembly.GetManifestResourceStream(resourceName))
    {
      return new Icon(stream);
    }
  }
}