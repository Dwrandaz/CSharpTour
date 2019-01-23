using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTour.Linq
{
    public class ExhibitC
    {
        public static void Run()
        {
            var text1 = "someone@something.com";
            var text2 = "John smith";

            // IsEmail can be used as if its actually a method on the String class
            Console.WriteLine($"{text1} is Email? {text1.IsEmail()}");
            Console.WriteLine($"{text2} is Email? {text2.IsEmail()}");
        }
    }
}
