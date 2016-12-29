public class NumberDaoFactory
{
    public static INumberDao Create(string key)
    {
        return new NumberFile(key);
    }
}
