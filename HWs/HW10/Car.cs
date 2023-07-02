using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HW10
{
    public abstract class Car 
    {
        public Car(string model) 
        { 
            this .model = model;
        }
        public string model = "-1";
        public int MaxSpeed = 50;
        public string BrakesPedal = "stop";
        public string AcceleratorPedal = "accelerator pedal";
        virtual public void trip()
        {
            Console.WriteLine(AcceleratorPedal + " " + MaxSpeed + " " + "BrakesPedal");
        }
    }
    public class BMW: Car
    {
        public BMW(string model) : base(model)
        {
            this.model = model;
        }
        public override void trip()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine($"BMW {model}:" + ( AcceleratorPedal+" Fast speed accelerastion ")+(MaxSpeed + 200)+" " + BrakesPedal + " in 10 sec");
        }

    }
    public class Porshe : Car
    {
        public Porshe(string model) : base(model)
        {
            this.model = model;
        }
        public override void trip()
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Porshe {model}:" + (AcceleratorPedal + " hight speed ") + (MaxSpeed + 250) + " " + BrakesPedal + "In 5 sec");
        }
    }
}
 