namespace Cancellation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = Enumerable.Range(0, 1000000).ToArray();

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            ParallelOptions parallelOptions = new ParallelOptions();
            parallelOptions.CancellationToken = cancellationTokenSource.Token;
            parallelOptions.MaxDegreeOfParallelism = System.Environment.ProcessorCount;

            Console.WriteLine("Press 'x' to cancel");

            Task.Factory.StartNew(() =>
            {
                if (Console.ReadKey().KeyChar == 'x')
                {
                    cancellationTokenSource.Cancel();
                }
            });

            long total = 0;
            try
            {
                Parallel.For(0,
                    list.Length,
                    parallelOptions,
                    () => 0,
                    (count, parallelLoopState, subTotal) =>
                    {
                        parallelOptions.CancellationToken.ThrowIfCancellationRequested();
                        subTotal += list[count];
                        return subTotal;
                    },
                    (x) =>
                    {
                        Interlocked.Add(ref total, x);
                    });
            }
            catch (OperationCanceledException opEx)
            {
                Console.WriteLine("Cancelled: " + opEx.Message);
            }
            finally { cancellationTokenSource.Cancel(); }

            Console.WriteLine("Final sum: " + total);
        }
    }
}