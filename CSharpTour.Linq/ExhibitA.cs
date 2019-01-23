using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpTour.Linq
{
    public class ExhibitA
    {
        public static void Run()
        {
            var list = new List<int> { 1, 2, 3, 4, 5 };
            var enumeable = list.Where(i => i > 2);

            foreach(var n in enumeable)
            {
                Console.WriteLine(n);
            }

            Console.WriteLine();

            list.Add(9);

            // Notice the result changes!
            // That's because IEnumerable sequences are lazily evaluated.
            foreach (var n in enumeable)
            {
                Console.WriteLine(n);
            }

            Console.WriteLine();

            // IQuerable is used to represent a query, not to execute it
            // It is used to translate LINQ queries to SQL, web requests, etc...
            var querable = list.AsQueryable().Where(i => i > 2 && i % 2 == 0);

            Console.WriteLine(querable.Expression);
        }
    }
}
