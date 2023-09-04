using System.Collections;
using System.Net;

namespace HW21
{
    internal class Program
    {
        public class AdressGIZ 
        {

            enum Area_List
            {
                North,
                Center,
                West,
                East,
                South
            }
            enum North_Oblast_List
            {
                Cherkasy,
                Chernihiv,
                Kyiv,
                Sumy,

            }
            enum Center_Oblast_List
            {
                Khmelnytskyi,
                Ternopil,
                Vinnytsia,
                Chernivtsi,
                Zhytomyr
            }
            enum West_Oblast_List
            {
                Ivano_Frankivsk,
                Lviv,
                Rivne,
                Volyn,
                Zakarpattia
            }
            enum East_Oblast_List
            {
                Dnipropetrovsk,
                Donetsk,
                Kharkiv,
                Kirovohrad,
                Luhansk,
                Poltava,
                Zaporizhzhia,
            }
            enum South_Oblast_List
            {
                Kherson,
                Mykolaiv,
                Odesa,
            }
            public string Area = "-1";
            public string Oblast = "-1";
            public string District = "-1";
            public string Hromada = "-1";
            public string Settlement_name = "-1";
            public string Street = "-1";
            public string building = "-1";
            public string Post_index = "-1";

            public bool AreaValidation (AdressGIZ adress)
            {
                var logFilePath = @"C:\test\Log.txt";
                using StreamWriter writer = new StreamWriter (logFilePath);
                
                                  
                    if (!Enum.IsDefined(typeof(Area_List), adress.Area)) 
                    {
                        writer.WriteLine($"{DateTime.Now}, Invalid Area");
                    return false;
                    }
                switch ((Area_List)Enum.Parse(typeof(Area_List), adress.Area))
                {
                    case Area_List.North:
                        if (!Enum.IsDefined(typeof(North_Oblast_List), adress.Oblast))
                        {
                            writer.WriteLine($"{DateTime.Now}, Invalid Oblast North");
                            return false;
                        }
                        break;
                    case Area_List.Center:
                        if (!Enum.IsDefined(typeof(Center_Oblast_List), adress.Oblast))
                        {
                            writer.WriteLine($"{DateTime.Now}, Invalid Oblast Center");
                            return false;
                        }
                        break;
                    case Area_List.West:
                        if (!Enum.IsDefined(typeof(West_Oblast_List), adress.Oblast))
                        {
                            writer.WriteLine($"{DateTime.Now}, Invalid Oblast West");
                            return false;
                        }
                        break;
                    case Area_List.East:
                        if (!Enum.IsDefined(typeof(East_Oblast_List), adress.Oblast))
                        {
                            writer.WriteLine($"{DateTime.Now}, Invalid Oblast East");
                            return false;
                        }
                        break;
                    case Area_List.South:
                        if (!Enum.IsDefined(typeof(South_Oblast_List), adress.Oblast))
                        {
                            writer.WriteLine($"{DateTime.Now}, Invalid Oblast East");
                            return false;
                        }
                        
                        break;

                    default:
                        return true;

                        break;
                }
                return true;

            }
        }

        static void Main(string[] args)
        {
            List<AdressGIZ> adressGIZs = new List<AdressGIZ>();
            AdressGIZ adress1 = new AdressGIZ();
            adress1.Area= "North";
            adress1.Oblast = "Kyiv";
            adress1.District = 
            adress1.Hromada = "Bila Tserkva";
            adress1.Settlement_name = "Bila Tserkva";
            adress1.Street = "Shevchenko";
            adress1.building = "12";
            adress1.Post_index = "09100";
            adressGIZs.Add(adress1);
            AdressGIZ adress2 = new AdressGIZ();
            adress2.Area = "South";
            adress2.Oblast = "Odesa";
            adress2.District = "Odesa";
            adress2.Hromada = "Odesa";
            adress2.Settlement_name = "Odesa";
            adress2.Street = "Deribasivska";
            adress2.building = "5";
            adress2.Post_index = "65000";
            adressGIZs.Add(adress2);
            AdressGIZ adress3 = new AdressGIZ();
            adress3.Area = "South";
            adress3.Oblast = "Odesa";
            adress3.District = "CHornomorsk";
            adress3.Hromada = "CHornomorsk";
            adress3.Settlement_name = "CHornomorsk";
            adress3.Street = "DMyru Avenue";
            adress3.building = "63";
            adress3.Post_index = "68000";
            adressGIZs.Add(adress3);
            AdressGIZ adress4 = new AdressGIZ();
            adress4.Area = "North";
            adress4.Oblast = "Odesa";
            adress4.District = "CHornomorsk";
            adress4.Hromada = "CHornomorsk";
            adress4.Settlement_name = "CHornomorsk";
            adress4.Street = "Myru Avenue";
            adress4.building = "63";
            adress4.Post_index = "68000";
            adressGIZs.Add(adress4);
            List<AdressGIZ> southAddresses = adressGIZs.Where(address => address.Area == "South").ToList();
            foreach (var address in southAddresses)
            {
                Console.WriteLine($"Area: {address.Area}, Oblast: {address.Oblast}, District: {address.District}, Hromada: {address.Hromada}, Settlement_name: {address.Settlement_name}, Street: {address.Street}, Building: {address.building}, Post_index: {address.Post_index}");
            }
        }
    }
}