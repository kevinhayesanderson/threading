namespace Deadlocks
{
    internal class Program
    {
        private static object lock1 = new object();
        private static object lock2 = new object();

        private static void Main(string[] args)
        {
            new Thread(() =>
            {
                lock (lock1)
                {
                    Console.WriteLine("lock1 obtained");
                    Thread.Sleep(2000);
                    lock (lock2)//lock2 waits for main thread to release it
                    {
                        Console.WriteLine("lock2 obtained");
                    }
                }
            }).Start();

            lock (lock2)
            {
                Console.WriteLine("Main thread obtained lock2");
                Thread.Sleep(1000);
                lock (lock1) //lock1 waits for the worker thread to release it
                {
                    Console.WriteLine("Main thread obtained lock1");
                }
            }

            //both of them are waiting on each other creating deadlock
        }
    }
}