using System;
using System.IO;

public class NumberFile : INumberDao
{
    private string Filename;

    public NumberFile(string nameKey)
    {
        Filename = Config.PersistentDataPath + "/" + nameKey + ".txt";
    }

    public void Save(Number number)
    {
        File.Write(Filename, number.Value.ToString());
    }
}
