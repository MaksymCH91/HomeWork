using System.Diagnostics;

namespace HW28
{
    class Program
    {
        static void Main(string[] args)
        {
             
           
            for (int i = 1; i <= Environment.ProcessorCount; i++)
            {
                Console.WriteLine($"numbers of treads: {i}");
                int[] numbers = Enumerable.Range(1, 100000000).ToArray();
                var stopwatch = Stopwatch.StartNew();

                var result = numbers.AsParallel()
                    .WithDegreeOfParallelism(i) // set numbe rs of treads
                    .Where(x => x % 2 == 0)
                    .Select(x => x * x)
                    .ToList();

                stopwatch.Stop();

                Console.WriteLine($"Result: {result.Count}");
                Console.WriteLine($"Execution time: {stopwatch.ElapsedMilliseconds} ms");
            }
            

            Console.ReadLine();
        }
    }
}