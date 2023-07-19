namespace TaskChaining
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Task<string> antecedent = Task.Run(async () =>
            {
                await Task.Delay(2000);
                return DateTime.Today.ToShortDateString();
            });
            Task<string> continuation = antecedent.ContinueWith(x =>
            {
                return $"Today is {antecedent.Result}";
            });

            Console.WriteLine("This will display before the result");
            Console.WriteLine(continuation.Result);
        }
    }
}