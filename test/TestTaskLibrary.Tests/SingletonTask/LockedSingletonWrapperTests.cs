using TestTaskLibrary.SingletonTask;

namespace TestTaskLibrary.UnitTests.SingletonTask;

public class LockedSingletonWrapperTests
{
    private const int _listItemCount = 6;
    readonly List<object?> lst = new(_listItemCount);

    [Test]
    public void LockedSingletonWrapperGetInstance_test()
    {
        Parallel.For(0, _listItemCount, x =>
        {
            lst.Add(LockedSingletonWrapper<object>.GetInstance());

        });

        CollectionAssert.AllItemsAreNotNull(lst);
        Assert.That(lst.Select(x => x), Is.All.SameAs(lst.ElementAt(0)));
    }
}
