using System.Diagnostics;

namespace Tpl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Time taken:" + stopwatch.ElapsedMilliseconds);
            stopwatch.Stop();

            stopwatch.Start();
            Parallel.For(0, 10, Console.WriteLine);
            Console.WriteLine("Time taken:" + stopwatch.ElapsedMilliseconds);

        }
    }
}