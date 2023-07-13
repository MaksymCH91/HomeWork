using System.Collections.Generic;
using System.Xml.Linq;

namespace HW8

{
    internal class Program
    {
        private static void Main(string[] args)
    

        {
            bool laap = true;
            List<Person> People = new List<Person>();
            People.Add(new Person("Name", "Adress", "Phone number"));
            People.Add(new Person("Maksym", "Khreschhatuk 28", "+380677834290"));
            People.Add(new Person("Petro", "Mukhailivska 7", "+3805045698563"));
            People.Add(new Person("Katia", "A Uzviz 7", "+380969035566"));
            do
            {
                Console.Write(
                    "Please input requre operation\n" +
                    "list - Show all element\n" +
                    "add - Add new elemtnt\n"+
                    "find - Find information according Name Or Phone\n"+
                    "exit - End program\n" + 
                    "What is your choise:");
                switch (Console.ReadLine())
                {
                    case "list":
                        MyMetod.PrintAll(People);
                        break;
                    case "add":
                        MyMetod.AddPerson(People);
                        break;
                    case "find":
                        MyMetod.FindPerson(People);
                        break;
                    case "exit":
                        laap = false;
                        break;
                    default:
                        Console.WriteLine("Unknown operation\n"+"Please try again");
                        break;
                }

                             
            
            }

            while (laap);

        }
        
        
    }
}