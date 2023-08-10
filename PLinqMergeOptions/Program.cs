namespace PLinqMergeOptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = Enumerable.Range(1, 100);
            var query = from n in list.AsParallel().WithMergeOptions(ParallelMergeOptions.NotBuffered)
                        where n % 2 == 0
                        select n;
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
        }
    }
}