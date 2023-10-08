using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Numerics;

namespace HW28
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= Environment.ProcessorCount; i++)
            {
                Console.WriteLine($"Number of threads: {i}");
                int[] numbers = Enumerable.Range(1, 100000000).ToArray();
                var stopwatch = Stopwatch.StartNew();

                var result = numbers.AsParallel()
                    .WithDegreeOfParallelism(i)
                    .Where(x => x % 2 == 0)
                    .Select(x => BigInteger.Pow(x, 2)) // Use BigInteger for intermediate result
                    .Aggregate(BigInteger.Zero, (subtotal, x) => BigInteger.Add(subtotal, x)); // Use BigInteger for aggregation

                stopwatch.Stop();

                Console.WriteLine($"Result: {result}");
                Console.WriteLine($"Execution time: {stopwatch.ElapsedMilliseconds} ms");
            }

            Console.ReadLine();
        }
    }





















}