using BenchmarkDotNet.Running;
using TeskTaskLibrary.PerfomanceTests;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        var summary = BenchmarkRunner.Run<BenchmarkListTask>();
    }
}