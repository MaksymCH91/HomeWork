using System;

internal class Program
{
	private static void Main(string[] args)
	{
     
        ReverseWriteArray(ArrayGenerator());
		Console.ReadLine();

		static void ReverseWriteArray(int[,] Array_IN)
		{
			for (int i = 0; i <= Array_IN.GetLength(0) - 1; i++)
			{
				for (int j = 0; j <= Array_IN.GetLength(1) - 1; j++)
				{
					Console.Write(Array_IN[i, j] + " ");

				}
				Console.WriteLine();
			}

			Console.WriteLine();
			for (int i = Array_IN.GetLength(0) - 1; i >= 0; i--)
			{
				for (int j = Array_IN.GetLength(1) - 1; j >= 0; j--)
				{
					Console.Write(Array_IN[i, j] + " ");

				}
				Console.WriteLine();
			}

		}
        static int[,] ArrayGenerator()
		{
            Random rand = new Random();
            int x, y;
            do
            {
                Console.WriteLine("enter the dimensions of a two-dimensional array");
                Console.Write("X=");
                bool parseX = Int32.TryParse(Console.ReadLine(), out x);
                Console.Write("Y=");
                bool parseY = Int32.TryParse(Console.ReadLine(), out y);

                if ((parseX || parseY) == true) break;

                else Console.WriteLine("Please re-enter the dimensions");
            }
            while (true);
            int[,] Array1 = new int[x, y];
            for (int i = 0; i <= Array1.GetLength(0) - 1; i++)
            {
                for (int j = 0; j <= Array1.GetLength(1) - 1; j++)
                {
                    Array1[i, j] = rand.Next(1, 100);

                }

            }
            return Array1;
        }
    }


}
