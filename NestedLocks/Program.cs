namespace NestedLocks
{
    internal class Program
    {
        static object lock1  = new object();
        static void Main(string[] args)
        {
           lock(lock1) //Parent lock holds the lock on the resource
            {
                DoSth();
            }
        }

        private static void DoSth()
        {
            lock(lock1)
            {
                Task.Delay(2000).Wait();
                AnotherMethod();
            }
        }

        private static void AnotherMethod()
        {
            lock (lock1)
            {
                Console.WriteLine("Another Method");
            }
        }
    }
}