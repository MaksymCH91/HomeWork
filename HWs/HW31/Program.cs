using System.Xml.Serialization;
using Newtonsoft.Json;

namespace HW31
{
    public class Data
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }

        public Data()
        {
            // Constructor to initialize data
            Console.Write("Enter name: ");
            Name = Console.ReadLine();
            Console.Write("Enter age: ");
            Age = int.Parse(Console.ReadLine());
            Console.Write("Enter email: ");
            Email = Console.ReadLine();
        }
    }

    public class XMLManager
    {
        private Data data;

        public XMLManager(Data data)
        {
            this.data = data;
        }

        public void Save(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Data));
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(fileStream, data);
            }
            Console.WriteLine("Data saved in XML format.");
        }

        public void Load(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Data));
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
            {
                Data loadedData = (Data)serializer.Deserialize(fileStream);
                Console.WriteLine("Data loaded from XML file:");
                Console.WriteLine($"Name: {loadedData.Name}");
                Console.WriteLine($"Age: {loadedData.Age}");
                Console.WriteLine($"Email: {loadedData.Email}");
            }
        }
    }

    public class JSONManager
    {
        private Data data;

        public JSONManager(Data data)
        {
            this.data = data;
        }

        public void Save(string filePath)
        {
            string jsonData = JsonConvert.SerializeObject(data);
            File.WriteAllText(filePath, jsonData);
            Console.WriteLine("Data saved in JSON format.");
        }

        public void Load(string filePath)
        {
            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);
                Data loadedData = JsonConvert.DeserializeObject<Data>(jsonData);
                Console.WriteLine("Data loaded from JSON file:");
                Console.WriteLine($"Name: {loadedData.Name}");
                Console.WriteLine($"Age: {loadedData.Age}");
                Console.WriteLine($"Email: {loadedData.Email}");
            }
            else
            {
                Console.WriteLine("JSON file not found.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string xmlFilePath = @"d:\test1\data.xml"; // path to xml file 
            string jsonFilePath = @"d:\test1\data.json";// path to jsong file

            Data data = new Data();

            XMLManager xmlManager = new XMLManager(data);
            JSONManager jsonManager = new JSONManager(data);

            xmlManager.Save(xmlFilePath);
            jsonManager.Save(jsonFilePath);

            xmlManager.Load(xmlFilePath);
            jsonManager.Load(jsonFilePath);
        }
    }
}