using System.Diagnostics;

namespace HW27
{
    class Program
    {
    static async Task Main(string[] args)
    {
        int numThreads = Environment.ProcessorCount; // Кількість доступних процесорних ядер за замовчуванням

       
       
            numThreads = 4; // Використовуємо задану кількість потоків, якщо користувач вказав параметр
        

        Console.WriteLine($"Using {numThreads} thread(s) for asynchronous execution.");

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
            for (int i = 1; i < 1000000; i++)
            {
                Task<int> task = CalculateAsync(10, numThreads); 
                int result = await task;
                Console.WriteLine($"Result: {result}");
            }
        

        Console.WriteLine("Task started");

        

        stopwatch.Stop();
        ;
        Console.WriteLine($"Time taken: {stopwatch.ElapsedMilliseconds}ms");
    }

    static async Task<int> CalculateAsync(int number, int numThreads)
    {
        return await Task.Run(() => CalculateSquare(number, numThreads));
    }

    static int CalculateSquare(int number, int numThreads)
    {
        Console.WriteLine($"Calculating square of {number} using {numThreads} thread(s).");

        // Демонстраційна операція обчислення квадрату (тут може бути реальний важкий обчислювальний код)
        int result = number * number;

        return result;
    }
}
}