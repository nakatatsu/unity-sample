using System;
using System.IO;

public static class DataFile
{
    public static void Write(string filePath, string contents)
    {
        using (var fileStream = new FileStream(filePath, System.IO.FileMode.Create, System.IO.FileAccess.Write, System.IO.FileShare.None))
        {
            using (var writer = new StreamWriter(fileStream))
            {
                writer.Write(contents);
            }
        }
    }
}
