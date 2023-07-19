namespace TaskIntro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task task = new Task(SimpleMethod);
            task.Start();
            task.Wait();

            Task<string> taskThatReturns = new Task<string>(MethodThatReturns);
            taskThatReturns.Start();
            taskThatReturns.Wait();
            Console.WriteLine(taskThatReturns.Result);

            ///https://stackoverflow.com/questions/29693362/regarding-usage-of-task-start-task-run-and-task-factory-startnew
            ///https://devblogs.microsoft.com/pfxteam/task-factory-startnew-vs-new-task-start/
            Task<string> taskA = Task.Run(MethodThatReturns);
            taskA.Wait();
            Console.WriteLine(taskA.Result);
        }

        private static string MethodThatReturns()
        {
            Thread.Sleep(2000);
            return "Hello";
        }

        private static void SimpleMethod()
        {
            Console.WriteLine("Hello World");
        }
    }
}