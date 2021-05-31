using System;
using System.Collections.Generic;

namespace GenericCountMethodDoubles
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<double> list = new List<double>();
            for (int i = 0; i < n; i++)
            {
                list.Add(double.Parse(Console.ReadLine()));
            }
            Box<double> box = new Box<double>(list);
            Console.WriteLine(box.CountOfGreaterValues(double.Parse(Console.ReadLine())));
        }
    }
}
