
namespace ThreadPoolDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Thread.CurrentThread.IsThreadPoolThread);
            Employee employee = new Employee();
            employee.Name = "TestName";
            employee.CompanyName = "TestCompany";
            ThreadPool.QueueUserWorkItem(new WaitCallback(DisplayEmployeeInfo), employee);

            var processorCount = Environment.ProcessorCount;
            ThreadPool.SetMaxThreads(processorCount*2, processorCount*2);

            ThreadPool.GetMinThreads(out int workerThreads, out int completionPortThreads);

            ThreadPool.SetMaxThreads(workerThreads * 2, completionPortThreads * 2);

            Console.WriteLine(Thread.CurrentThread.IsThreadPoolThread);
            Console.ReadKey();
        }

        private static void DisplayEmployeeInfo(object? state)
        {
            Console.WriteLine(Thread.CurrentThread.IsThreadPoolThread);
            if (state is Employee employee)
            {
                Console.WriteLine($"Name:{employee.Name}, Company:{employee.CompanyName}");
            }
        }
    }

    public class Employee
    {
        public string? Name { get; set; }
        public string? CompanyName { get; set; }
    }
}