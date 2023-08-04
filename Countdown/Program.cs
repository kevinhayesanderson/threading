namespace Countdown
{
    internal class Program
    {
        private static CountdownEvent countdownEvent = new CountdownEvent(5);

        static void Main(string[] args)
        {
            Task.Factory.StartNew(DoSomething);
            Task.Factory.StartNew(DoSomething);
            Task.Factory.StartNew(DoSomething);
            Task.Factory.StartNew(DoSomething);
            Task.Factory.StartNew(DoSomething);
            countdownEvent.Wait();
            Console.WriteLine("Signal has been called 5 times");
        }

        private static void DoSomething()
        {
            Thread.Sleep(2500);
            Console.WriteLine($"{Task.CurrentId} is calling signal");
            countdownEvent.Signal();
        }
    }
}