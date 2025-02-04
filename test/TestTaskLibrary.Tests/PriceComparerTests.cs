using AutoFixture;
using TestTaskLibrary.DictionaryTask;

namespace TestTaskLibrary.Tests;

public class PriceComparerTests
{
    private IFixture _fixture;
    private Dictionary<Price, Product> _productsPrices;

    [OneTimeSetUp]
    public void Setup()
    {
        _fixture = new Fixture();
    }

    [SetUp]
    public void SetupRepeat()
    {
        _productsPrices = new(new PriceComparer());
    }

    [Test]
    public void PriceComparerTryAddExistedKey_Test()
    {

        var price = _fixture.Create<Price>();
        var product = _fixture.Create<Product>();


        Assert.IsTrue(_productsPrices.TryAdd(price, product));
        Assert.IsFalse(_productsPrices.TryAdd(price, product));

    }

    [Test]
    public void IsPriceDictionaryContiansThisPrice_Test()
    {

        var counter = 15;

        var prices = _fixture.CreateMany<Price>(counter);
        var products = _fixture.CreateMany<Product>(counter);

        for (int i = 0; i < counter; i++)
        {
            _productsPrices.Add(prices.ElementAt(i), products.ElementAt(i));
        }

        foreach (var item in prices)
        {
            Assert.That(item.IsDictionaryContiansThisPrice(_productsPrices), Is.True);
        }
    }
}