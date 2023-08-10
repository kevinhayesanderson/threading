using System.Diagnostics;
using System.Drawing;

namespace ParallelvsNormal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var path = Directory.GetCurrentDirectory();
            var files = Directory.GetFiles(path + @"\pictures", "*.jpg");
            var alteredPath = path + @"\alteredPath";
            Directory.CreateDirectory(alteredPath);

            ParallelExecution(files, alteredPath);

            NormalExecution(files, alteredPath);
        }

        private static void NormalExecution(string[] files, string alteredPath)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            foreach (var currentFile in files)
            {
                var file = Path.GetFileName(currentFile);
                using var fileBitMap = new Bitmap(currentFile);
                fileBitMap.RotateFlip(RotateFlipType.Rotate270FlipXY);
                fileBitMap.Save(Path.Combine(alteredPath, file));
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}");
            }
            Console.WriteLine("NormalExecution:" + stopwatch.ElapsedMilliseconds);
            stopwatch.Stop();
        }

        private static void ParallelExecution(string[] files, string alteredPath)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            Parallel.ForEach(files, currentFile =>
            {
                var file = Path.GetFileName(currentFile);
                using var fileBitMap = new Bitmap(currentFile);
                fileBitMap.RotateFlip(RotateFlipType.Rotate270FlipXY);
                fileBitMap.Save(Path.Combine(alteredPath, file));
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}");
            });
            Console.WriteLine("ParallelExecution:" + stopwatch.ElapsedMilliseconds);
            stopwatch.Stop();
        }
    }
}