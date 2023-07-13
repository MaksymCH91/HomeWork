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
        public static void PrintAll(List<Person> people)
        {
            foreach (var item in people)
            {
                Console.WriteLine(item.Name + "\t \t \t" + item.Adress + "\t \t \t" + item.Pnumber);
            }
        }
        static public  void AddPerson(List<Person> people)
        {
            Console.Write("Pleases input new contact in format  Name,Adress;Phone number :");
            string[] Temp = Console.ReadLine().Split(',');
            people.Add(new Person(Temp[0], Temp[1], Temp[2]));
            Console.WriteLine("Adding of Contact is sussecful");
            PrintPerson(people, 0);
            PrintPerson(people, people.Count-1);
        }
        static public void PrintPerson(List<Person> people, int index)

        {
            Console.WriteLine(people[index].Name + "\t \t \t" + people[index].Adress + "\t \t \t" + people[index].Pnumber);
        }
        static public void FindPerson(List<Person> people)
        {
            Console.Write("Input name or phon to find details: ");
            string Variable = Console.ReadLine();
            if (people.FindIndex(p => p.Name == Variable) != -1)
            {
                {
                    PrintPerson(people, 0);
                    PrintPerson(people, people.FindIndex(p => p.Name == Variable));
                }
            }
            else if (people.FindIndex(p => p.Pnumber == Variable) != -1)
            {
                PrintPerson(people, 0);
                PrintPerson(people, people.FindIndex(p => p.Pnumber == Variable));

            }
            else { Console.WriteLine("There are no result"); }
        }
    }
    
}
