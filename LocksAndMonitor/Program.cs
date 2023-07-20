namespace LocksAndMonitor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Account account = new Account(20000);
            Task task1 = Task.Run(account.WithdrawRandomly);
            Task task2 = Task.Run(account.WithdrawRandomly);
            Task task3 = Task.Run(account.WithdrawRandomly);
            Task.WaitAll(task1,task2,task3);
            Console.WriteLine("All tasks complete");
        }
    }
}