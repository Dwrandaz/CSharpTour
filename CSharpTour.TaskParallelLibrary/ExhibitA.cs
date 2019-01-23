using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpTour.TaskParallelLibrary
{
    public class ExhibitA
    {
        public static void Run()
        {
            var watch = new Stopwatch();
            watch.Start();

            for (int i = 0; i < 1_000_000; i++)
            {
                for (int j = 0; j < 1_000; j++)
                {
                    int r = i * j;
                }
            }

            watch.Stop();
            Console.WriteLine($"Sequential: {watch.ElapsedMilliseconds:N0}");
            watch.Restart();

            Parallel.For(0, 1_000_000, i =>
            {
                for (int j = 0; j < 1_000; j++)
                {
                    int r = i * j;
                }
            });

            Console.WriteLine($"Parallel For: {watch.ElapsedMilliseconds:N0}");
            watch.Restart();
        }
    }
}
