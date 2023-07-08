using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HW10
{
    interface IRadio
    {
        string TurnOn(string model);
        string TurnOff(string model);
        string ChangeStation(string model);
        string IncreaseVolume(string model);

    }
    interface ISeats
    {
        string AdjustPosition(string model);
        string HeatOn(string model);
        string HeatOff(string model);

    }
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
    public class BMW: Car, IRadio, ISeats
    {
        public BMW(string model) : base(model)
        {
            this.model = model;
        }
        public string TurnOn(string model) { return this.model = model + " Radio turn on"; }
        public string TurnOff(string model) { return this.model = model + " Radio turn off"; }
        public string ChangeStation(string model) { return this.model = model + " Changed radio station to 937"; }
        public string IncreaseVolume(string model) { return this.model = model + " Volume +5"; }
        public string AdjustPosition(string model) { return this.model = model + "  Position Up"; }
        public string HeatOn(string model) { return this.model = model + " heat on"; }
        public string HeatOff(string model) { return this.model = model + " heat off"; }
        
        public void PrintInteffaceComponents()
        {
           Console.WriteLine($"{TurnOn(model)}\n{TurnOff(model)}\n{ChangeStation(model)}\n{IncreaseVolume(model)}\n{AdjustPosition(model)}\n{HeatOn(model)}\n{HeatOff(model)}\n");
        }

        public override void trip()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine($"BMW {model}:" + ( AcceleratorPedal+" Fast speed accelerastion ")+(MaxSpeed + 200)+" " + BrakesPedal + " in 10 sec");
        }

    }
    public class Porshe : Car,IRadio,ISeats
    {
        public Porshe(string model) : base(model)
        {
            this.model = model;
        }
        public string TurnOn(string model) { return this.model = model + " Radio turn on"; }
        public string TurnOff(string model) { return this.model = model + " Radio turn off"; }
        public string ChangeStation(string model) { return this.model = model + " Changed radio station to 135"; }
        public string IncreaseVolume(string model) { return this.model = model + " Volume +2"; }
        public string AdjustPosition(string model) { return this.model = model + "  Position down"; }
        public string HeatOn(string model) { return this.model = model + " heat on"; }
        public string HeatOff(string model) { return this.model = model + " heat off"; }

        public void PrintInteffaceComponents()
        {
            Console.WriteLine($"{TurnOn(model)}\n{TurnOff(model)}\n{ChangeStation(model)}\n{IncreaseVolume(model)}\n{AdjustPosition(model)}\n{HeatOn(model)}\n{HeatOff(model)}\n");
        }
        public override void trip()
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Porshe {model}:" + (AcceleratorPedal + " hight speed ") + (MaxSpeed + 250) + " " + BrakesPedal + "In 5 sec");
        }
    }
}
 