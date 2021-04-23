using System;

namespace IntOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());
            int fourth = int.Parse(Console.ReadLine());
            second += first;
            second /= third;
            second *= fourth;
            Console.WriteLine(second);
        }
    }
}
