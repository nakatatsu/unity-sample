using System;
using System.IO;

public class Logic
{
    public bool Check(string input)
    {
        int number;
        bool canParse = Int32.TryParse(input, out number);
        return canParse;
    }

    public double Pow(int number)
    {
        var result = Math.Pow(number, 2);
        Save(Config.PersistentDataPath + "/pow.txt", result.ToString());
        return result;
    }

    public int Increment(int number)
    {
        var result = number + 1;
        Save(Config.PersistentDataPath + "/increment.txt", result.ToString());
        return result;
    }

    public int Decrement(int number)
    {
        var result = number - 1;
        Save(Config.PersistentDataPath + "/decrement.txt", result.ToString());
        return result;
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
