using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "1 2 3 4 5 6 7 8 9   ";
            string[] b = a.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine(string.Join(" ", b));
        }
    }
}
