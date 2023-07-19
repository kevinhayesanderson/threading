namespace Exceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Demo();
        }

        private static void Demo()
        {
            //try
            //{
            //Worker Thread
            new Thread(Execute).Start();
            //}
            ////Main Thread Catch
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
        }

        static void Execute() ///catch where you expect exception 
        {
            try
            {
                throw null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}