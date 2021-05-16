using System;

namespace _2._Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split();
            Action<string> print = p => Console.WriteLine($"Sir {p}");
            foreach (var person in names)
            {
                print(person);
            }
        }
    }
}
