using System;

namespace _1._Action_Point
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] persons = Console.ReadLine().Split();
            Action<string> print = p => Console.WriteLine(p);
            foreach (var person in persons)
            {
                print(person);
            }
        }
    }
}
