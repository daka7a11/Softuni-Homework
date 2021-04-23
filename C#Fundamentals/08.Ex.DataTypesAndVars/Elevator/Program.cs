using System;

namespace Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int person = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());
            int courses =(int)Math.Ceiling(person / (double)capacity);
            Console.WriteLine(courses);
        }
    }
}
