using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTour.Linq
{
    public class ExhibitB
    {
        private class Thing
        {
            public double Price { get; set; }
        }

        public static void Run()
        {
            foreach (var n in GenerateThings(6))
            {
                Console.WriteLine($"Price: {n.Price:N2}");
            }
        }

        private static readonly Random _random = new Random();

        public static IEnumerable<int> GenerateInts(int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return i;
            }
        }

        private static IEnumerable<Thing> GenerateThings(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var thing = new Thing
                {
                    Price = _random.NextDouble() * 100
                };

                yield return thing;
            }
        }

        // Cant use yield inside try-catch block!

        //public static IEnumerable<int> Generate(int count)
        //{
        //    try
        //    {
        //        for (int i = 0; i < count; i++)
        //        {
        //            yield return i;
        //        }
        //    }
        //    catch (Exception)
        //    {

        //    }
        //}
    }
}
