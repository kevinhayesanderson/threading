namespace threading
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(WriteUsingNewThread);
            //Worker Thread
            thread.Start();
            //Main Thread
            for (int i = 0; i < 1000; i++)
            {
                Console.Write(" A" + i + " ");
            }
        }

        private static void WriteUsingNewThread(object? obj)
        {
            for (int i = 0; i< 1000; i++)
            {
                Console.Write(" Z" + i+ " ");
            }
        }
    }
}