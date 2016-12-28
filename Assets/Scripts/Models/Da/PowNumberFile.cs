using System;
using System.IO;

public class PowNumberFile : INumberDao
{
    public void Save(Number number)
    {
        Utils.WriteFile(Config.PersistentDataPath + "/pow.txt", number.ToString());
    }
}
