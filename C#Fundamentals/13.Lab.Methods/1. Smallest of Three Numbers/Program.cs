using System;

namespace _1._Smallest_of_Three_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());
            SmallestInt(num1, num2, num3);
        }
        static void SmallestInt(int num1, int num2, int num3)
        {
            int minNum = Math.Min(Math.Min(num1, num2),num3);
            Console.WriteLine(minNum);
        }
    }
}
