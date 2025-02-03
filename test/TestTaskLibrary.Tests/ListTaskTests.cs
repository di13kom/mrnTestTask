using AutoFixture;
using TestTaskLibrary.ListTask;

namespace TestTaskLibrary.Tests;

public class ListTaskTests
{
    private IFixture _fixture;

    [OneTimeSetUp]
    public void Setup()
    {
        _fixture = new Fixture();
    }

    [Test]
    public void ComposeProductRubPricesNewWith20ProductShouldReturn20Values()
    {
        int productsCount = 20;
        int pricesCount = 50;

        var queue = new Queue<int>(Enumerable.Range(1, productsCount));
        var products = _fixture.Build<Product>()
                               .With(x => x.Id, () => queue.Dequeue())
                               .CreateMany(productsCount);

        var queuePrices = new Queue<int>(Enumerable.Range(1, pricesCount));

        var prices = _fixture.Build<Price>()
                             .With(x => x.ProductId, () => queuePrices.Dequeue())
                             .With(x => x.Currency, "RUB")
                             .CreateMany(pricesCount);

        var productRubPrices = ProductRubPriceProcessing.ComposeProductRubPricesNew(products.ToList(), prices.ToList());

        CollectionAssert.IsNotEmpty(productRubPrices);
        Assert.That(productRubPrices, Has.Count.EqualTo(productsCount));

    }

}
