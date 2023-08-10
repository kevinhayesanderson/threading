namespace TaskCompletionSourceDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TaskCompletionSource<Product> taskCompletionSource = new TaskCompletionSource<Product>();
            Task<Product> lazyTask = taskCompletionSource.Task;

            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(2000);
                taskCompletionSource.SetResult(new Product()
                {
                    Id = 1,
                    Name = "Test Product"
                });
            });

            Task.Factory.StartNew(() =>
            {
                if (Console.ReadKey().KeyChar == 'x')
                {
                    Product result = lazyTask.Result;
                    Console.WriteLine($"Result is {result.Name}");
                }
            });

            Thread.Sleep(5000);
            Console.ReadLine();
        }
    }

    internal class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}