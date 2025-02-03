using TestTaskLibrary.CustomWhereTask;

namespace TestTaskLibrary.Tests;

public class CustomWhereTests
{
    Func<int, bool> _testCondition = x => x >= 5 && x <= 10;

    [Test]
    public void CustomWhereEmptyCollectionReturnEmpty_test()
    {
        IEnumerable<int> lst = Enumerable.Empty<int>();

        var tstLst = lst.CustomWhere(_testCondition);

        CollectionAssert.IsEmpty(tstLst);
    }

    [Test]
    public void CustomWhereNullCollectionReturnEmpty_test()
    {
        List<int>? lst = null;

        var tstLst = lst.CustomWhere(_testCondition);

        CollectionAssert.IsEmpty(tstLst);
    }

    [Test]
    public void CustomWhereIntCollectionContainsOnlyFiveToTenRange_test()
    {

        IEnumerable<int> lst = Enumerable.Range(0, 30);

        var tstLst = lst.CustomWhere(_testCondition);

        Assert.That(tstLst, Is.All.Matches<int>(x => x >= 5 && x <= 10));
    }

    [Test]
    public void CustomWhereIntCollectionReturnEmptyWithWrongCondition_test()
    {
        Func<int, bool> testCondition = x => x < 10;

        IEnumerable<int> lst = Enumerable.Range(10, 30);

        var tstLst = lst.CustomWhere(testCondition);

        Assert.That(tstLst, Is.All.Matches<int>(x => x < 10));
    }
}
