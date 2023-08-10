namespace PLinqIntro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = Enumerable.Range(1, 100000);
            var primeNumbers = list.AsParallel().Where(x =>
            {
                if(x == 1) return false;
                if(x == 2) return true;
                if(x % 2 == 0) return false;
                var boundary = (int)Math.Floor(Math.Sqrt(x));
                for(int i = 3; i <= boundary; i+=2)
                {
                    if(x % i == 0)
                        return false;
                }
                return true;
            });
            Console.WriteLine($"{primeNumbers.Count()} prime numbers found");
        }
    }
}