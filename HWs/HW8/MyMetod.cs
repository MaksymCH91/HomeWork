using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HW8
{
    internal class MyMetod
    {
        public static void PrintAll(List<Person> People)
        {
            foreach (var item in People)
            {
                Console.WriteLine(item._Name + "\t \t \t" + item._Adress + "\t \t \t" + item._Pnumber);
            }
        }
        static public  void AddPerson(List<Person> People)
        {
            Console.Write("Pleases input new contact in format  Name,Adress;Phone number :");
            string[] Temp = Console.ReadLine().Split(',');
            People.Add(new Person(Temp[0], Temp[1], Temp[2]));
            Console.WriteLine("Adding of Contact is sussecful");
            PrintPerson(People, 0);
            PrintPerson(People, People.Count-1);
        }
        static public void PrintPerson(List<Person> People, int index)

        {
            Console.WriteLine(People[index]._Name + "\t \t \t" + People[index]._Adress + "\t \t \t" + People[index]._Pnumber);
        }
        static public void FindPerson(List<Person> People)
        {
            Console.Write("Input name or phon to find details: ");
            string Variable = Console.ReadLine();
            if (People.FindIndex(p => p._Name == Variable) != -1)
            {
                {
                    PrintPerson(People, 0);
                    PrintPerson(People, People.FindIndex(p => p._Name == Variable));
                }
            }
            else if (People.FindIndex(p => p._Pnumber == Variable) != -1)
            {
                PrintPerson(People, 0);
                PrintPerson(People, People.FindIndex(p => p._Pnumber == Variable));

            }
            else { Console.WriteLine("There are no result"); }
        }
    }
    
}
