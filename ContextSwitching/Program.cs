namespace ContextSwitching
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Thread thread = new Thread(WriteUsingNewThread);
            thread.Name = "Worker 1";
            //Worker Thread
            thread.Start();
            //Main Thread
            Thread.CurrentThread.Name = "Main";
            for (int i = 0; i < 1000; i++)
            {
                Console.Write(" A" + i + " ");
            }
        }

        private static void WriteUsingNewThread(object? obj)
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.Write(" Z" + i + " ");
            }
        }
    }
}