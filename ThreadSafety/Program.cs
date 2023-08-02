namespace ThreadSafety
{
    internal class Program
    {
        static Dictionary<int, string> items = new Dictionary<int, string>();
        static void Main(string[] args)
        {
            var task1 = Task.Factory.StartNew(AddItem);
            var task2 = Task.Factory.StartNew(AddItem);
            var task3 = Task.Factory.StartNew(AddItem);
            var task4 = Task.Factory.StartNew(AddItem);
            var task5 = Task.Factory.StartNew(AddItem);
            Task.WaitAll(task1, task2, task3, task4, task5);
        }

        private static void AddItem()
        {
            lock (items)
            {
                Console.WriteLine($"Lock 1 acquired by {Task.CurrentId}");
                items.Add(items.Count, $"data {items.Count}");
            }

            Dictionary<int, string> dictionary;
            lock (items)
            {
                Console.WriteLine($"Lock 2 acquired by {Task.CurrentId}");
                dictionary = items;
                foreach (var (key, value) in dictionary)
                {
                    Console.WriteLine($"{key} {value}");
                }
            }

            
        }
    }
}