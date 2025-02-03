using BenchmarkDotNet.Attributes;
using TestTaskLibrary.ListTask;
using Price = TestTaskLibrary.ListTask.Price;
using Product = TestTaskLibrary.ListTask.Product;

namespace TeskTaskLibrary.PerfomanceTests;

public class BenchmarkListTask
{

    List<Product> _products;
    List<Price> _prices;

    public BenchmarkListTask()
    {
        _products = CreateProducts();
        _prices = CreatePrices();

    }
    private static List<Price> CreatePrices()
    {
        int randomSeed = 300;
        var random = new Random(randomSeed);
        int pricesCollectionLength = 10_000;
        var pricesCollection = new List<Price>(pricesCollectionLength);

        for (int i = 1; i <= pricesCollectionLength; i++)
        {
            pricesCollection.Add(new()
            {
                ProductId = i,
                Amount = random.Next(),
                Currency = "RUB",
            });
        }

        return pricesCollection;
    }

    private static List<Product> CreateProducts()
    {
        int productCollectionLength = 10_000;
        var productCollection = new List<Product>(productCollectionLength);

        for (int i = 1; i <= productCollectionLength; i++)
        {
            productCollection.Add(new Product()
            {
                Id = i,
                Name = string.Concat("product_", i)
            });
        }

        return productCollection;
    }

    [Benchmark]
    public IList<ProductRubPrice> CheckComposeProductRubPricesPerformance()
    {
        return ProductRubPriceProcessing.ComposeProductRubPrices(_products, _prices);
    }

    [Benchmark]
    public IList<ProductRubPrice> CheckComposeProductRubPricesNewPerformance()
    {
        return ProductRubPriceProcessing.ComposeProductRubPricesNew(_products, _prices);
    }
}