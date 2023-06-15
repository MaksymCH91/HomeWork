// See https://aka.ms/new-console-template for more information
using System;

int[,] Array1 = new int[,] { {1, 2, 3, 4, 5 }, { 6, 7, 8, 9, 10 }, { 11, 12, 13, 14, 15 }, { 16, 17, 18, 19, 20 }, { 21, 22, 23, 24, 25 } };

for (int i =0; i <= Array1.GetLength(0)-1; i++)
{
    for (int j = 0; j <= Array1.GetLength(1)-1; j++)
   {
       Console.Write(Array1[i, j] + " ");

   }
    Console.WriteLine();
}

Console.WriteLine();
for (int i = Array1.GetLength(0) - 1; i >=0;i--)
{
	for (int j = Array1.GetLength(1) - 1; j >= 0; j--)
	{
		Console.Write(Array1[i, j] + " ");

	}
	Console.WriteLine();
}
Console.ReadLine();