namespace TasksIo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task<string> task = Task.Factory.StartNew<string>(() => GetPosts("https://jsonplaceholder.typicode.com/posts"));

            SomethingElse();
            //task.Wait();

            try
            {
                Console.WriteLine(task.Result);
            }
            catch (AggregateException agEx)
            {
                Console.WriteLine(agEx.Message);
                foreach (var innerException in agEx.InnerExceptions)
                {
                    Console.WriteLine(innerException.Message);
                }
            }
        }

        private static void SomethingElse()
        {
            Console.WriteLine("Dummy Implementation");
        }

        private static string GetPosts(string uri)
        {
            //throw null;
            using var client = new HttpClient();
            return client.GetStringAsync(uri).Result;
        }
    }
}