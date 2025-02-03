namespace TestTaskLibrary.SingletonTask;
public sealed class LockedSingletonWrapper<T> where T : class, new()
{
    private static T? _instance = null;
    private static readonly object syncObject = new object();

    LockedSingletonWrapper() { }

    public static T GetInstance()
    {
        lock (syncObject)
        {
            if (_instance is null)
            {
                _instance = new();
            }
            return _instance;
        }

    }
}