using System;
using System.Collections.Generic;

namespace GenericCountMethodStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> list = new List<string>();
            for (int i = 0; i < n; i++)
            {
                list.Add(Console.ReadLine());
            }
            Box<string> box = new Box<string>(list);
            Console.WriteLine(box.CountOfGreaterValues(Console.ReadLine()));
        }
    }
}
