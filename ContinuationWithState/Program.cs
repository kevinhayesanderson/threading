namespace ContinuationWithState
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task<DateTime> task = Task.Run(DoSomething);
            List<Task<DateTime>> continuationTasks = new List<Task<DateTime>>();
            for (int i = 0; i < 3; i++)
            {
                task = task.ContinueWith((x, y) => DoSomething(), new Person { Id=i});
                continuationTasks.Add(task);
            }
            task.Wait(); 
            foreach (var continuation in continuationTasks)
            {
                Person person = continuation.AsyncState as Person;
                Console.WriteLine($"Task finished at {continuation.Result}. Person id is {person.Id}");
            }
        }

        public static DateTime DoSomething()
        {
            return DateTime.Now;
        }
    }

    internal class Person
    {
        public int Id { get; set; }
    }
}