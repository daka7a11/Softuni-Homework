using System;

namespace _7._Predicate_for_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();
            Func<string, bool> checkLength = GetLength(n);
            foreach (var name in names)
            {
                if (checkLength(name))
                {
                    Console.WriteLine(name);
                }

            }
        }
        static Func<string, bool> GetLength(int n)
        {
            return s => s.Length <= n;
        }
    }
}
