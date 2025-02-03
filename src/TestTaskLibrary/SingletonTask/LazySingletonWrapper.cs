public sealed class LazySingletonWrapper<T> where T : new()
{
    private static Lazy<T> _instance = new Lazy<T>(() => new());

    private LazySingletonWrapper(){ }

    public static T GetInstance=> _instance.Value;
}