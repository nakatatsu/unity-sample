public class MediatorFactory { 
    public static T Create<T>() where T : new()
    {
        return new T();
    }
}