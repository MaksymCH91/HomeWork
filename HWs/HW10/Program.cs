using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.Xml.Linq;

namespace HW10

{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List < Car > Cars = new List<Car>()
            {
                new Bmw(KindOfBmw.X5), new Porshe("CareraGT"),new Bmw (KindOfBmw.X2)
            }; 
       foreach (var Car in Cars)
            {
                Car.Trip();
                Console.WriteLine();
                
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Bmw bmwx2 = null;
            do
            {
                Console.Write("Input model: ");
                
                string modelOfCar = Console.ReadLine();
                try
                {
                    bmwx2 = new Bmw(Enum.Parse<KindOfBmw>(modelOfCar));
                }
                catch (Exception )
                {

                    Console.WriteLine("Please re-input model of BMW");
                }
            } while ( bmwx2 != null);

            bmwx2.PrintInteffaceComponents();
            Porshe CareraGt = new Porshe("CareraGT");
            CareraGt.PrintInteffaceComponents ();   

        }


    }
}