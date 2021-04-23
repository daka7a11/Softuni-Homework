using System;
using System.Collections.Generic;

namespace _4._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<decimal>> products = new Dictionary<string, List<decimal>>();
            string[] input = Console.ReadLine().Split();
            while (input[0].ToLower()!="buy")
            {
                string name = input[0];
                decimal price = decimal.Parse(input[1]);
                int quantity = int.Parse(input[2]);
                if (!products.ContainsKey(name))
                {
                    products.Add(name, new List<decimal> {price,quantity});
                }
                else
                {
                    products[name][0] = price;
                    products[name][1] += quantity;
                }
                input = Console.ReadLine().Split();
            }
            foreach (var x in products)
            {
                Console.WriteLine($"{x.Key} -> {x.Value[0]*x.Value[1]:F2}");
            }
        }
    }
}
