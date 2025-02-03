using System.Runtime.CompilerServices;

namespace TestTaskLibrary.AsyncEnumerableTask;

public static class AsyncEnumerableExtension
{
    public static async IAsyncEnumerable<List<T>> ToBatchesAsync<T>(this IAsyncEnumerable<T> source,
                                                                   int batchSize,
                                                                   [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var returnBatch = new List<T>();
        await foreach (var item in source)
        {
            if (cancellationToken.IsCancellationRequested)
                yield break;
            returnBatch.Add(item);
            if (returnBatch.Count >= batchSize)
            {
                yield return returnBatch;
                returnBatch = new List<T>();
            }
        }
        if (returnBatch.Count > 0)
        {
            yield return returnBatch;
        }
    }

    public static async IAsyncEnumerable<int> CreateAsyncEnumerable(int count)
    {
        for (int i = 0; i < count; i++)
        {
           await Task.Delay(10);
           yield return i;
        }
    }
}
