using System.Diagnostics.CodeAnalysis;

namespace TestTaskLibrary.ListTask;

public class ProductRubPrice : IEquatable<ProductRubPrice>
{
    public string ProductName { get; set; } = null!;
    public decimal Amount { get; set; }

    public bool Equals([DisallowNull] ProductRubPrice? other) => ProductName.Equals(other.ProductName) && Amount.Equals(other.Amount);
    public override int GetHashCode() => HashCode.Combine(Amount, ProductName);//Amount.GetHashCode() ^ ProductName.GetHashCode();

}
