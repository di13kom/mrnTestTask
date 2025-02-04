namespace TestTaskLibrary.DictionaryTask;

public record Product(int Weight, int Height)
{
    public string Name { get; set; } = null!;

    public string Color { get; set; } = null!;
}