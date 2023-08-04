namespace AutoReset
{
    internal class Program
    {
        ////static EventWaitHandle autoResetEvent = new EventWaitHandle(false, EventResetMode.AutoReset);
        
        static AutoResetEvent eventWaitHandle = new AutoResetEvent(false);
        
        static void Main(string[] args)
        {
            Task.Factory.StartNew(WorkerThread);
            Thread.Sleep(2500);
            eventWaitHandle.Set();
        }

        private static void WorkerThread()
        {
            Console.WriteLine($"Waiting to enter the gate");
            eventWaitHandle.WaitOne();
            //Logic
            Console.WriteLine($"Gate entered");
        }
    }
}