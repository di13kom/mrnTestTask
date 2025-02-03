
using BenchmarkDotNet.Attributes;

namespace TestTaskLibrary.ListTask;
public static class ProductRubPriceProcessing
{
    public static IList<ProductRubPrice> ComposeProductRubPricesNew(IList<Product> products, IList<Price> prices)
    {
        Dictionary<int, Product> productDict = products.DistinctBy(x => x.Id)
                                                       .ToDictionary(x => x.Id);
        HashSet<ProductRubPrice> productPrices = [];
        foreach (var item in prices)
        {
            if (item.Currency == "RUB" && productDict.TryGetValue(item.ProductId, out var value))
            {
                productPrices.Add(new() { Amount = item.Amount, ProductName = value.Name });
            }
        }

        return productPrices.ToList();
    }

    public static IList<ProductRubPrice> ComposeProductRubPrices(IList<Product> products, IList<Price> prices)
    {
        var productPrices = new List<ProductRubPrice>();

        foreach (var product in products)
        {
            var filteredPrices = prices.Where(p => p.ProductId == product.Id && p.Currency == "RUB")
                                       .Select(p => new ProductRubPrice { Amount = p.Amount, ProductName = product.Name })
                                       .ToList();

            if (filteredPrices.Any())
            {
                productPrices.AddRange(filteredPrices);
            }
        }

        return productPrices.Distinct()
                            .ToList();
    }


}
