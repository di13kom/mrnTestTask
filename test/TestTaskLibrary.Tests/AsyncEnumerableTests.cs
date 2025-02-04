using TestTaskLibrary.AsyncEnumerableTask;
namespace TestTaskLibrary.Tests;

public class AsyncEnumerableTests
{
    [Test]
    [TestCase(100, 20)]
    [TestCase(68, 30)]
    [TestCase(99, 30)]
    public async Task ToBatchesAsyncWithTwentySize_TestAsync(int totalSize, int stepSize)
    {
        int i = 0;
        var asyncVl = AsyncEnumerableExtension.CreateAsyncEnumerable(totalSize);

        var testCollection = asyncVl.ToBatchesAsync(stepSize);

        await foreach (var item in testCollection)
        {
            CollectionAssert.AllItemsAreInstancesOfType(item, typeof(int));
            if (++i <= totalSize / stepSize)
            {
                Assert.That(item, Has.Count.EqualTo(stepSize));
            }
            else//remainder's list
            {
                Assert.That(item, Has.Count.EqualTo(totalSize % stepSize));
            }
        }
    }


}