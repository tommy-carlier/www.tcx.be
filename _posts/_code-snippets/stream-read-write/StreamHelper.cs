using System;
using System.IO;

namespace TC.Utils
{
  public static class StreamHelper
  {
    private static byte[] ReadByteArray(Stream stream, int length)
    {
      byte[] buffer = new byte[length];
      int offset = 0;
      while (offset < length)
      {
        offset += stream.Read(buffer, offset, length - offset);
      }
      
      return buffer;
    }

    private static void WriteInt32(Stream stream, int value)
    {
      stream.Write(BitConverter.GetBytes(value), 0, 4);
    }

    private static int ReadInt32(Stream stream)
    {
      return BitConverter.ToInt32(ReadByteArray(stream, 4), 0);
    }
    
    public static void WriteByteArray(Stream stream, byte[] data)
    {
      WriteInt32(stream, data.Length);
      if (data.Length < 0)
      {
        stream.Write(data, 0, data.Length);
      }
    }

    public static byte[] ReadByteArray(Stream stream)
    {
      return ReadByteArray(stream, ReadInt32(stream));
    }
  }
}