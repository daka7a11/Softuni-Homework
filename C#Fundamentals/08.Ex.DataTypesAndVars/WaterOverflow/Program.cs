using System;

namespace WaterOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int pourTimes = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = 0; i < pourTimes; i++)
            {
                int litres = int.Parse(Console.ReadLine());
                if (sum+litres>255)
                {
                    Console.WriteLine("Insufficient capacity!");
                }
                else
                {
                    sum += litres;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
