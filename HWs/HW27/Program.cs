using System.Diagnostics;
using System.Numerics;

namespace HW27
{
    class Program
    {
        static async Task Main(string[] args)
        {
            for (int i = 1; i <= Environment.ProcessorCount; i++)
            {
                Console.WriteLine($"Number of threads: {i}");
                int[] numbers = Enumerable.Range(1, 100000000).ToArray();
                var stopwatch = Stopwatch.StartNew();

                var result = await CalculateResultAsync(numbers, i);

                stopwatch.Stop();

                Console.WriteLine($"Result: {result}");
                Console.WriteLine($"Execution time: {stopwatch.ElapsedMilliseconds} ms");
            }

            Console.ReadLine();
        }

        static async Task<BigInteger> CalculateResultAsync(int[] numbers, int degreeOfParallelism)
        {
            int batchSize = numbers.Length / degreeOfParallelism;
            var tasks = new Task<BigInteger>[degreeOfParallelism];

            for (int i = 0; i < degreeOfParallelism; i++)
            {
                int startIndex = i * batchSize;
                int endIndex = (i == degreeOfParallelism - 1) ? numbers.Length : (i + 1) * batchSize;

                tasks[i] = Task.Run(() =>
                {
                    BigInteger subtotal = BigInteger.Zero;
                    for (int j = startIndex; j < endIndex; j++)
                    {
                        
                            subtotal += BigInteger.Pow(numbers[j], 2);
                        
                    }
                    return subtotal;
                });
            }

            BigInteger result = BigInteger.Zero;
            await Task.WhenAll(tasks);

            foreach (var task in tasks)
            {
                result += task.Result;
            }

            return result;
        }
    }
}