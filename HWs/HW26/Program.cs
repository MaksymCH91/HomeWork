using System.Diagnostics;

namespace HW26
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Enumerable.Range(1, 1000000).ToArray();
       
            for (int i = 1; i < Environment.ProcessorCount; i++)
            {
                timeOfCalculation(numbers, i);
            }
          
        }

                static void timeOfCalculation(int[] numbers,int numThreads)
        {
            Stopwatch St1 = new Stopwatch();
            long sum = 0;
            St1.Start();
            //  Parallel.ForEach
            Parallel.ForEach(numbers, new ParallelOptions { MaxDegreeOfParallelism = numThreads }, (number) =>
            {
                long result = Calculate(number);
                Interlocked.Add(ref sum, result); //adding to sum with lock (Interlocked.Add)
            });

            Console.WriteLine("Sum: " + sum);
            St1.Stop();
            Console.WriteLine($"time with {numThreads} treads \t" + St1.Elapsed.TotalMicroseconds);
                  }
            
        static long Calculate(int number)
        {
            return (long)number * number;
        }
    }
}