using System;

namespace CSharpTour.Delegates
{
    public class ExhibitB
    {
        public static void Run()
        {
            var person = new Person { Name = "Jaafar", Age = 120 };

            DoSomething(person, p => Console.WriteLine($"{person.Name} is saved!"));

            // Multicast Actions
            Action<Person> action = p =>
            {
                Console.WriteLine($"First Action: {p.Name}");
            };

            action += SayHello;
            action(person);
        }

        public static void DoSomething(Person person, Action<Person> callback)
        {
            // Pretend to write to the database
            Console.WriteLine($"Writing {person.Name} to database...");

            callback(person);

            Console.WriteLine("Done.");
        }

        public static void SayHello(Person person)
        {
            Console.WriteLine($"Hello {person.Name}");
        }
    }
}
