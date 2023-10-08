namespace HW30
{
    class Program
    {
        static void Main()
        {
            MyObject obj = new MyObject();
            obj.Run();
        }
    }

    class MyObject
    {
        public void Run()
        {
            string[] dataArray = new string[10];
            FillArrayWithData(dataArray);

            MyOtherObject otherObj = new MyOtherObject(dataArray);
            otherObj.Dispose();
        }

        private void FillArrayWithData(string[] dataArray)
        {
            Random random = new Random();
            for (int i = 0; i < dataArray.Length; i++)
            {
                dataArray[i] = $"{random.Next(1000)}";
            }
        }
    }

    class MyOtherObject : IDisposable
    {
        private string[] data;

        public MyOtherObject(string[] dataArray)
        {
            data = dataArray;
        }

        public void Dispose()
        {
            Console.WriteLine($"Number of elements in the array: {data.Length}");

            foreach (string item in data)
            {
                Console.WriteLine(item);
            }

            GC.Collect();
             PrintElementsUsingUnsafe();
            GC.WaitForPendingFinalizers();

            Console.WriteLine("MyOtherObject has been disposed.");
        }
        private unsafe void PrintElementsUsingUnsafe()
        {
            fixed (string* ptr = data)
            {
                for (int i = 0; i < data.Length; i++)
                {
                    ptr[i] = ptr[1];
                    Console.WriteLine($"Element {i + 1}: {ptr[i]}");
                }
            }
        }
    }
}