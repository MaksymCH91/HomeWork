using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace HW10

{
    internal class Program
    {
        static void Main(string[] args)
        {
            List < Car > Cars = new List<Car>()
            {
                new BMW("x5"), new Porshe("Carera GT"),new BMW ("X2")
            }; 
       foreach (var Car in Cars)
            {
                Car.trip();
                Console.WriteLine();
                
            }
            Console.BackgroundColor = ConsoleColor.Black;
           
            BMW bmwx2 = new BMW("X2");
            bmwx2.PrintInteffaceComponents();
            Porshe CareraGT = new Porshe("CareraGT");
            CareraGT.PrintInteffaceComponents ();   

        }


    }
}