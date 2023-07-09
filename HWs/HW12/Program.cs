using System.Collections;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace HW12
{
    internal class Program
    {
        public static int FindElement(object[] arr, object val)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == val) { return i; };
            }
            return -1;
        }
        public static int FindElement(int[] arr, int val)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == val) { return i; };
            }
            return -1;
        }
        static void Main(string[] args)
        {
            const int n = 2000000;
            int[] Arr1 = new int[n];
            object[] Arr2 = new object[n];
            Random rnd = new Random();
            for (int i = 0; i < n - 1; i++)
            {
                Arr1[i] = rnd.Next();
                Arr2[i] = rnd.Next();

            }
            Stopwatch St1 = new Stopwatch();
            Stopwatch St2 = new Stopwatch();
            St1.Start();
            int num1 = FindElement(Arr1, -1);
            St1.Stop();
            St2.Start();
            int num2 = FindElement(Arr2, -1);
            St2.Stop();
            Console.WriteLine("Int\t" + St1.Elapsed.TotalMicroseconds);
            Console.WriteLine("Int\t" + St2.Elapsed.TotalMicroseconds);
            Console.ReadLine();
        }
    }
}