// See https://aka.ms/new-console-template for more information



int[] MyArray = new int[] { 5, 8, 10, 12, 15 };
foreach (var item in MyArray)
{
    Console.Write(item + " ");
}
Console.WriteLine();

Console.Write("Enter the number whose index you want to find (if number is not in array answer:-1): ");

bool a =int.TryParse(Console.ReadLine(),out int requaredNumber);
if (a == false) Console.WriteLine("Wrong type of value"); 
int index = Array.FindIndex(MyArray, x => x == requaredNumber);
Console.WriteLine(index);
Console.ReadLine();


