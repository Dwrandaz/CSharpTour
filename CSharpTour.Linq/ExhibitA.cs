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

            foreach (var n in enumeable)
            {
                Console.WriteLine(n);
            }

            Console.WriteLine();

            var querable = list.AsQueryable().Where(i => i > 2 && i % 2 == 0);

            Console.WriteLine(querable.Expression);
        }
    }
}
