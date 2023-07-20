namespace ReaderWriterlocks
{
    internal class Program
    {
        static ReaderWriterLockSlim readerWriterLockSlim = new ReaderWriterLockSlim();
        static Dictionary<int, string> persons = new Dictionary<int, string>();
        static Random random = new Random();

        static void Main(string[] args)
        {
            var task1 = Task.Factory.StartNew(Read);
            var task2 = Task.Factory.StartNew(Read);
            var task3 = Task.Factory.StartNew(Read);
            var task4 = Task.Factory.StartNew(Write, "task4");
            var task5 = Task.Factory.StartNew(Write, "task5");
            var task6 = Task.Factory.StartNew(Write, "task6");

            Task.WaitAll(task1,task2, task3, task4, task5, task6);

            Console.WriteLine("Hello, World!");
        }

        static void Read()
        {
            for (int i = 0; i < 10; i++)
            {
                readerWriterLockSlim.EnterReadLock();
                Thread.Sleep(50); //simulating read operation
                readerWriterLockSlim.ExitReadLock();
            }
        }
        static void Write(object user)
        {
            for (int i = 0; i < 10; i++)
            {
                int id = GetRandom();
                readerWriterLockSlim.EnterWriteLock();
                var person = $"Person {i}";
                persons[id] = person;
                readerWriterLockSlim.ExitWriteLock();
                Console.WriteLine($"{user} added {person}");
                Thread.Sleep(250);
            }
        }

        static int GetRandom()
        {
            lock (random)
            {
                return random.Next(2000, 5000);
            }
        }
    }
}