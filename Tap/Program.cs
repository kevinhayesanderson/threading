namespace Tap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;


            Task.Factory.StartNew(() => {
                Thread.Sleep(4000);
                cts.Cancel();
            });

            DownloadAsync(new Uri("https://jsonplaceholder.typicode.com/posts"), token).Wait();
        }

        public static async Task DownloadAsync(Uri uri, CancellationToken cancellationToken)
        {
            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();
                try
                {
                    HttpResponseMessage response = await GetAsync(uri);
                    Console.WriteLine(response);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static Task<HttpResponseMessage> GetAsync(Uri uri)
        {
            HttpClient client = new HttpClient();
            return client.GetAsync(uri);
        }
    }
}