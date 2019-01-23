using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTour.TaskParallelLibrary
{
    public class ExhibitB
    {
        public static void Run()
        {
            Console.WriteLine("Generating list...");
            var list = Enumerable.Repeat(1, 1_000_000).ToArray();
            Console.WriteLine("Done...");

            var watch = new Stopwatch();
            watch.Start();

            foreach(var item in list)
            {
                for (int j = 0; j < 1_000; j++)
                {
                    int r = item * j;
                }
            }

            watch.Stop();
            Console.WriteLine($"Sequential: {watch.ElapsedMilliseconds:N0}");
            watch.Restart();

            Parallel.For(0, list.Length, i =>
            {
                for (int j = 0; j < 1_000; j++)
                {
                    int r = list[i] * j;
                }
            });

            Console.WriteLine($"Parallel For: {watch.ElapsedMilliseconds:N0}");
            watch.Restart();

            Parallel.ForEach(list, item =>
            {
                for (int j = 0; j < 1_000; j++)
                {
                    int r = item * j;
                }
            });

            Console.WriteLine($"Parallel ForEach: {watch.ElapsedMilliseconds:N0}");
            watch.Restart();

            list.AsParallel().ForAll(item =>
            {
                for (int j = 0; j < 1_000; j++)
                {
                    int r = item * j;
                }
            });

            Console.WriteLine($"AsParallel(): {watch.ElapsedMilliseconds:N0}");
        }
    }
}
