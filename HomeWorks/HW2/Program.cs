// See https://aka.ms/new-console-template for more information

//int Val1 = Convert.ToInt16(Console.ReadLine());
//*Console.Write(Val1 / 10000 + " " + Val1 / 1000%10 + " " + Val1 / 100%10+ " " + Val1 / 10%10 + " " + Val1 % 10);
//Console.ReadLine();




Console.WriteLine("Input text and press Enter");

string val = Console.ReadLine();

if (val == "")
{
    Console.WriteLine("The line is empty");
}
else
{
    foreach (char i in val)
    {
        Console.Write(i + " ");
    }
}

Console.ReadLine();
