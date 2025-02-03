namespace TestTaskLibrary.SingletonTask;

public class DoubleCheckSingleton<T> where T : class, new()
{
    private static T? _instance = null;
    private static object _syncObject = new object();

    private DoubleCheckSingleton() { }

    public static T GetInstance()
    {
        if (_instance == null)
        {
            lock (_syncObject)
            {
                if (_instance == null)
                {
                    _instance = new();
                }
            }
        }
        return _instance;
    }
}
