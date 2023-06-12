// See https://aka.ms/new-console-template for more information
 static bool IsPrimeNumber(uint n) // метод для визначення простих чисел
{
    var result = true;

    if (n > 1)
    {
        for (var i = 2u; i < n; i++)
        {
            if (n % i == 0)
            {
                result = false;
                break;
            }
        }
    }
    else
    {
        result = false;
    }

    return result;
}
Console.WriteLine("prime numbers from range of  a-b n= ");
Console.Write("a=");
uint a = Convert.ToUInt32(Console.ReadLine());
Console.Write("b=");
uint b = Convert.ToUInt32(Console.ReadLine());
Console.WriteLine("prime number from range   ({0}, {1}) is", a, b);
for (var i = a; i < b; i++)
{
    if (IsPrimeNumber(i))
    {
        Console.Write($"{i} ");
    }
}

Console.ReadLine();

