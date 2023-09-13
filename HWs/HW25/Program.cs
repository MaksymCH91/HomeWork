using System;

namespace HW25
{
    //internal class Program // variant with task and Semaphore
    //{
    //    static Semaphore semaphoreA = new Semaphore(1, 1);
    //    static Semaphore semaphoreB = new Semaphore(0, 1);
    //    static Semaphore semaphoreC = new Semaphore(0, 1);
    //    static int quantityOfLeter = 25;
    //    static void Main(string[] args)
    //    {
    //        Task t1 = Task.Factory.StartNew(WriteA);
    //        Task t2 = Task.Factory.StartNew(WriteB);
    //        Task t3 = Task.Factory.StartNew(WriteC);

    //        Task.WaitAll(t1, t2, t3);

    //        Console.WriteLine();
    //        Console.WriteLine("All threads have finished writing!");
    //    }

    //    static void WriteA()
    //    {
    //        for (int i = 0; i < quantityOfLeter; i++)
    //        {
    //            semaphoreA.WaitOne();
    //            Console.Write("A");
    //            semaphoreB.Release();
    //        }
    //    }

    //    static void WriteB()
    //    {
    //        for (int i = 0; i < quantityOfLeter; i++)
    //        {
    //            semaphoreB.WaitOne();
    //            Console.Write("B");
    //            semaphoreC.Release();
    //        }
    //    }

    //    static void WriteC()
    //    {
    //        for (int i = 0; i < quantityOfLeter; i++)
    //        {
    //            semaphoreC.WaitOne();
    //            Console.Write("C");
    //            semaphoreA.Release();
    //        }
    //    }
    //}
    class Program
    {
        static bool threadACompleted = true;
        static bool threadBCompleted = false;
        static bool threadCCompleted = false;
        static int quantityOfLeter = 25;
        static object lockObject = new object();
        static void Main(string[] args)
        {
            Thread threadA = new Thread(WriteA);
            Thread threadB = new Thread(WriteB);
            Thread threadC = new Thread(WriteC);

            threadA.Start();
            threadB.Start();
            threadC.Start();

            threadA.Join();
            threadB.Join();
            threadC.Join();

            Console.WriteLine();
            Console.WriteLine("All threads have finished writing!");
        }

        static void WriteA()
        {
            for (int i = 0; i < quantityOfLeter; i++)
            {
                lock (lockObject)
                {
                    while (!threadACompleted) // waiting for threadACompleted=true
                    {
                        Monitor.Wait(lockObject);// waiting for signal form other treat
                    }

                    Console.Write("A");
                    threadACompleted = false;
                    threadBCompleted = true;
                    Monitor.PulseAll(lockObject);// sisgnal of compliting task
                }
            }
        }

        static void WriteB()
        {
            for (int i = 0; i < quantityOfLeter; i++)
            {
                lock (lockObject)
                {
                    while (!threadBCompleted)
                    {
                        Monitor.Wait(lockObject);
                    }

                    Console.Write("B");
                    threadBCompleted = false;
                    threadCCompleted = true;
                    Monitor.PulseAll(lockObject);
                }
            }
        }

        static void WriteC()
        {
            for (int i = 0; i < quantityOfLeter; i++)
            {
                lock (lockObject)
                {
                    while (!threadCCompleted)
                    {
                        Monitor.Wait(lockObject);
                    }

                    Console.Write("C");
                    threadCCompleted = false;
                    threadACompleted = true;
                    Monitor.PulseAll(lockObject);
                }
            }
        }

        
    }
}