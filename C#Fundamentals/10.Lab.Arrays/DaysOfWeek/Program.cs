using System;

namespace DaysOfWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            int numDay = int.Parse(Console.ReadLine());
            if (numDay > 0 && numDay <= days.Length)
            {
                Console.WriteLine(days[numDay-1]);
            }
            else
            {
                Console.WriteLine("Invalid day!");
            }
        }
    }
}
