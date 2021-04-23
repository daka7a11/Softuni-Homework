using System;

namespace MultiplicationTable2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            if (num1 > 10)
            {
                Console.WriteLine($"{num1} X {num2} = {num1 * num2}");
            }
            else
            {
                for (int i = num2; i < 11; i++)
                {
                    Console.WriteLine($"{num1} X {i} = {num1 * i}");
                }
            }
        }
    }
}
