namespace HW10
{
    public enum KindOfBmw
{
    X2,
    X5,
    M1
}
   
    public enum KindOfPorshe
    {
      CareraGT,
      Panamera,
      M911
    }

    internal interface IRadio
    {
        string TurnOn(string model);
        string TurnOff(string model);
        string ChangeStation(string model);
        string IncreaseVolume(string model);

    }

    internal interface ISeats
    {
        string AdjustPosition(string model);
        string HeatOn(string model);
        string HeatOff(string model);

    }
    public abstract class Car 
    {
        public Car(string model) 
        { 
            this .Model = model;
        }
        public string Model = "-1";
        public int MaxSpeed = 50;
        public string BrakesPedal = "stop";
        public string AcceleratorPedal = "accelerator pedal";

        public virtual void Trip()
        {
            Console.WriteLine(AcceleratorPedal + " " + MaxSpeed + " " + "BrakesPedal");
        }
    }
    public class Bmw: Car, IRadio, ISeats
    {
        public Bmw(KindOfBmw model) : base(model.ToString())
        {
            this.Model = model.ToString();
        }
        public string TurnOn(string model) { return this.Model = model + " Radio turn on"; }
        public string TurnOff(string model) { return this.Model = model + " Radio turn off"; }
        public string ChangeStation(string model) { return this.Model = model + " Changed radio station to 937"; }
        public string IncreaseVolume(string model) { return this.Model = model + " Volume +5"; }
        public string AdjustPosition(string model) { return this.Model = model + "  Position Up"; }
        public string HeatOn(string model) { return this.Model = model + " heat on"; }
        public string HeatOff(string model) { return this.Model = model + " heat off"; }
        
        public void PrintInteffaceComponents()
        {
           Console.WriteLine($"{TurnOn(Model)}\n{TurnOff(Model)}\n{ChangeStation(Model)}\n{IncreaseVolume(Model)}\n{AdjustPosition(Model)}\n{HeatOn(Model)}\n{HeatOff(Model)}\n");
        }

        public override void Trip()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine($"BMW {Model}:" + ( AcceleratorPedal+" Fast speed accelerastion ")+(MaxSpeed + 200)+" " + BrakesPedal + " in 10 sec");
        }

    }
    public class Porshe : Car,IRadio,ISeats
    {
        public Porshe(string model) : base(model)
        {
            this.Model = model;
        }
        public string TurnOn(string model) { return this.Model = model + " Radio turn on"; }
        public string TurnOff(string model) { return this.Model = model + " Radio turn off"; }
        public string ChangeStation(string model) { return this.Model = model + " Changed radio station to 135"; }
        public string IncreaseVolume(string model) { return this.Model = model + " Volume +2"; }
        public string AdjustPosition(string model) { return this.Model = model + "  Position down"; }
        public string HeatOn(string model) { return this.Model = model + " heat on"; }
        public string HeatOff(string model) { return this.Model = model + " heat off"; }

        public void PrintInteffaceComponents()
        {
            Console.WriteLine($"{TurnOn(Model)}\n{TurnOff(Model)}\n{ChangeStation(Model)}\n{IncreaseVolume(Model)}\n{AdjustPosition(Model)}\n{HeatOn(Model)}\n{HeatOff(Model)}\n");
        }

        public override void Trip()
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Porshe {Model}:" + (AcceleratorPedal + " hight speed ") + (MaxSpeed + 250) + " " + BrakesPedal + "In 5 sec");
        }
    }
}
 