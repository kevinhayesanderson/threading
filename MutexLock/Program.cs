﻿namespace MutexLock
{
    internal class Program
    {
        static Mutex mutex = new Mutex();

        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                Thread thread = new Thread(AcquireMutex);
                thread.Name = $"Thread{i+1}";
                thread.Start();
            }
        }

        private static void AcquireMutex()
        {
            if(!mutex.WaitOne(TimeSpan.FromSeconds(1), false))
            {
                Console.WriteLine(Thread.CurrentThread.Name);
                return;
            }
            //mutex.WaitOne(); //returns true when mutex is not owned
            DoSomething();
            mutex.ReleaseMutex();
            Console.WriteLine($"Mutex released by {Thread.CurrentThread.Name}");
        }

        private static void DoSomething()
        {
            Thread.Sleep(3000);
        }
    }
}