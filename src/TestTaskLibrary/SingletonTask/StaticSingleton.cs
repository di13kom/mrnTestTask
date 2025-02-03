public sealed class StaticSingleton<T> where T : new()
{
    private static readonly T _instance = new();

    private StaticSingleton() { }

    static StaticSingleton() { }

    public static T GetInstance => _instance;
}