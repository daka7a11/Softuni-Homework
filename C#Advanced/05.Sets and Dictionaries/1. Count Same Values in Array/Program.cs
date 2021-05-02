using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Count_Same_Values_in_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<double, double> values = new Dictionary<double, double>();
            double[] arr = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();
            for (int i = 0; i < arr.Length; i++)
            {
                if (!values.ContainsKey(arr[i]))
                {
                    values.Add(arr[i],0);
                }
                values[arr[i]]++;
            }
            foreach (var item in values)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}
