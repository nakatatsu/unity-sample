using System;
using System.IO;

public static class Utils
{
    public static void WriteFile(string filePath, string contents)
    {
        using (var fileStream = new FileStream(filePath, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write, System.IO.FileShare.None))
        {
            using (var writer = new StreamWriter(fileStream))
            {
                writer.Write(contents);
            }
        }
    }
}
