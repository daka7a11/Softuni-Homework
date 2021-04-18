using System;

namespace _8._Factorial_Division
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal num1 = decimal.Parse(Console.ReadLine());
            decimal num2 = decimal.Parse(Console.ReadLine());
            Division(Factorial(num1),Factorial(num2));
        }
        static decimal Factorial(decimal num)
        {
            decimal sum = 1;
            for (int i = (int)num; i > 0; i--)
            {
                sum *= i;
            }
            return sum;
        }
        static void Division(decimal num1, decimal num2)
        {
            decimal number = num1 / num2;
            Console.WriteLine($"{number:F2}");
        }
    }
}
