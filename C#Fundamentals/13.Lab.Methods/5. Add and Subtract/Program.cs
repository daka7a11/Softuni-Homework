using System;

namespace _5._Add_and_Subtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());
            int number=Sub((Sum2Int(num1, num2)), num3);
            Console.WriteLine(number);

        }
        static int Sum2Int(int num1, int num2)
        {
            int sum = num1 + num2;
            return sum;
        }
        static int Sub(int sum, int num3)
        {
            int number = sum - num3;
            return number;
        }
    }
}
