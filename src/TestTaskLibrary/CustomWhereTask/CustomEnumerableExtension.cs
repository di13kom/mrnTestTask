namespace TestTaskLibrary.CustomWhereTask;

public static class CustomEnumerableExtension
{
    public static IEnumerable<T> CustomWhere<T>(this IEnumerable<T> source, Func<T, bool> searchCondition)
    {
        if (source is null)
            yield break;

        foreach (var item in source)
        {
            if (searchCondition(item))
            {
                yield return item;
            }
        }
    }
}
