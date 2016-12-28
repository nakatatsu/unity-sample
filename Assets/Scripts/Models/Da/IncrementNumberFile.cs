using System;
using System.IO;

public class IncrementNumberFile : INumberDao
{
    public void Save(Number number)
    {
        Utils.WriteFile(Config.PersistentDataPath + "/increment.txt", number.ToString());
    }
}
