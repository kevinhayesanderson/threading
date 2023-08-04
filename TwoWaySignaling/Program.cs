namespace TwoWaySignaling
{
    internal class Program
    {
        static EventWaitHandle first = new AutoResetEvent(false);
        static EventWaitHandle second = new AutoResetEvent(false);
        static object lockObj = new object();
        static string value = string.Empty;

        static void Main(string[] args)
        {
            Task.Factory.StartNew(WorkerThread);
            Console.WriteLine($"Main thread is waiting");
            first.WaitOne();

            lock (lockObj)
            {
                value = "Updating value in main thread";
                Console.WriteLine(value);
            }
            Thread.Sleep(1000);
            second.Set();
            Console.WriteLine("Released worker thread");
        }

        private static void WorkerThread()
        {
            Thread.Sleep(1000);
            lock(lockObj)
            {
                value = "Updating value in worker thread";
                Console.WriteLine(value);
            }
            first.Set();
            Console.WriteLine("Released main thread");
            Console.WriteLine("Worker thread is waiting");
            second.WaitOne();
        }
    }
}