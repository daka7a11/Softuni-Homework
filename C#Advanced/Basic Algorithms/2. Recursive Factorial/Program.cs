using System;

namespace _2._Recursive_Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine(Factorial(num));
        }
        static int Factorial(int num)
        {
            if (num == 1)
            {
                return num;
            }
            return num * Factorial(num - 1);
        }
    }
}
