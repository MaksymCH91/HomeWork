using System.Reflection;

namespace HW29
{
    class MyClass
    {
        public void Print(string message)
        {
            Console.WriteLine(message);
        }

        public void PrintCurrentTime()
        {
            Console.WriteLine($"Current Time: {DateTime.Now.ToString("HH:mm:ss")}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyClass obj = new MyClass();

            // List all available methods
            Console.WriteLine("Available methods:");
            Type myClassType = typeof(MyClass);
            foreach (MethodInfo methodInfo in myClassType.GetMethods())
            {
                Console.WriteLine(methodInfo.Name);
            }

            // Prompt for method selection
            Console.Write("Enter the method name to call (Print, PrintCurrentTime, or other): ");
            string methodName = Console.ReadLine();

            try
            {
                // Use reflection to call the selected method
                MethodInfo methodInfo = myClassType.GetMethod(methodName);

                if (methodInfo != null)
                {
                    methodInfo.Invoke(obj, null);
                }
                else
                {
                    Console.WriteLine("Method not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}