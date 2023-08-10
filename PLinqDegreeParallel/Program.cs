using System.Net.NetworkInformation;

namespace PLinqDegreeParallel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> sites = new List<string>();
            
            sites.Add("www.google.com");
            sites.Add("www.microsoft.com");
            sites.Add("www.apple.com");
           

            List<PingReply> pingReplies = sites
                .AsParallel()
                .WithDegreeOfParallelism(sites.Count)
                .Select(PingSites)
                .ToList();

            pingReplies.ForEach(pr => Console.WriteLine($"Address:{pr.Address} Status:{pr.Status} Time taken:{pr.RoundtripTime}"));
        }

        private static PingReply PingSites(string webSiteName)
        {
            Ping ping = new Ping();
            return ping.Send(webSiteName);
        }
    }
}