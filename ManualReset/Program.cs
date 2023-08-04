using System.Reflection;

namespace ManualReset
{
    internal class Program
    {
        private static ManualResetEvent resetEvent = new ManualResetEvent(false);

        ////private static EventWaitHandle waitHandle = new EventWaitHandle(false, EventResetMode.ManualReset);

        static void Main(string[] args)
        {
            Task.Factory.StartNew(CallWaitOne);
            Task.Factory.StartNew(CallWaitOne);
            Task.Factory.StartNew(CallWaitOne);
            Task.Factory.StartNew(CallWaitOne);
            Task.Factory.StartNew(CallWaitOne);

            Thread.Sleep(1000);
            Console.WriteLine("Press a key to release all the threads so far");
            Console.ReadKey();
            resetEvent.Set();

            Thread.Sleep(1000);
            Console.WriteLine("Press a key again. Threads won't block even if they call WaitOne");
            Console.ReadKey();
            Task.Factory.StartNew(CallWaitOne);
            Task.Factory.StartNew(CallWaitOne);
            Task.Factory.StartNew(CallWaitOne);
            Task.Factory.StartNew(CallWaitOne);
            Task.Factory.StartNew(CallWaitOne);

            Thread.Sleep(1000);
            Console.WriteLine("Press a key again. Threads will block if they call WaitOne");
            Console.ReadKey();
            resetEvent.Reset();
            Task.Factory.StartNew(CallWaitOne);
            Task.Factory.StartNew(CallWaitOne);
            Task.Factory.StartNew(CallWaitOne);
            Task.Factory.StartNew(CallWaitOne);
            Task.Factory.StartNew(CallWaitOne);

            Thread.Sleep(1000);
            Console.WriteLine("Press a key again. Calls Set() method");
            Console.ReadKey();
            resetEvent.Set();
        }

        private static void CallWaitOne()
        {
            Console.WriteLine($"{Task.CurrentId} has called {MethodBase.GetCurrentMethod().Name}");
            resetEvent.WaitOne();
            Console.WriteLine($"{Task.CurrentId} finally ended");
        }
    }
}