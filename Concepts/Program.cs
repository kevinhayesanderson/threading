namespace Concepts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(PrintHelloWorld);
            thread.Start();
            thread.IsBackground = true;
            thread.Join();
            Console.WriteLine("Hello World Printed");
        }

        private static void PrintHelloWorld()
        {
            Console.WriteLine("Hello World");
            Thread.Sleep(5000);
        }
    }
}