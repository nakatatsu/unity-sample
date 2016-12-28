using System;
using System.IO;

public class Logic
{
    public delegate void NumberChangedEventHandler(int sender);
    public event NumberChangedEventHandler Calculated;

    public void Pow(int number)
    {
        int result = (int) Math.Pow(number, 2);
        Save(Config.PersistentDataPath + "/pow.txt", result.ToString());
        Calculated(result);
    }

    public void Increment(int number)
    {
        int result = number + 1;
        Save(Config.PersistentDataPath + "/increment.txt", result.ToString());
        Calculated(result);
    }

    public void Decrement(int number)
    {
        int result = number - 1;
        Save(Config.PersistentDataPath + "/decrement.txt", result.ToString());
        Calculated(result);
    }

    private void Save(string filePath, string contents)
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
