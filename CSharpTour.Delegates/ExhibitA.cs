using System;

namespace CSharpTour.Delegates
{
    public class ExhibitA
    {
        public static void Run()
        {
            var person = new Person { Name = "Jaafar", Age = 120 };

            // We can pass methods as parameters to other methods
            Print(person, p => $"{p.Name} is {p.Age} years old.");
            Print(person, FormatPerson);
        }

        public static void Print(Person person, Func<Person, string> format)
        {
            Console.WriteLine(format(person));
        }

        public static string FormatPerson(Person person)
        {
            return $"Hello {person.Name}";
        }
    }
}
