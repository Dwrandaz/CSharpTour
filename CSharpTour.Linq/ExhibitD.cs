using System;
using System.Collections.Generic;

namespace CSharpTour.Linq
{
    public static class ExhibitD
    {
        public static void Run()
        {
            var list = new List<int> { 8, 2, 5, 7, 10 };
            var smallNumbers = list.Agar(i => i <= 5);

            foreach(var n in smallNumbers)
            {
                Console.WriteLine(n);
            }
        }

        // We can create new Linq operators!
        public static IEnumerable<T> Agar<T>(this IEnumerable<T> sequence, Func<T, bool> predicate)
        {
            foreach (var item in sequence)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }
    }
}
