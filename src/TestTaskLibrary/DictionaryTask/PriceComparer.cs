using System.Diagnostics.CodeAnalysis;

namespace TestTaskLibrary.DictionaryTask;

public class PriceComparer : EqualityComparer<Price>
{
    private readonly ushort myFactor = 100;
    public override bool Equals(Price? price0, Price? price1)
    {
        if (ReferenceEquals(price0, price1))
            return true;

        if (price0 is null || price1 is null)
            return false;

        return price0.Amount == price0.Amount && price0.CurrencyCode == price1.CurrencyCode;
    }

    public override int GetHashCode([DisallowNull] Price price) => HashCode.Combine(price.Amount, price.CurrencyCode);//(int)Math.Truncate(price.Amount * myFactor) ^ price.CurrencyCode;
}
