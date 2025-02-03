namespace TestTaskLibrary.DictionaryTask;
public class Price
{
    public decimal Amount { get; set; }
    public ushort CurrencyCode { get; set; }

    public bool IsDictionaryContiansThisPrice(Dictionary<Price, Product> dictionary)
    {
        return dictionary.TryGetValue(this, out var value);
    }
}
