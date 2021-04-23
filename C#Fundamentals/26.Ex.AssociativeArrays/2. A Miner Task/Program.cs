using System;
using System.Collections.Generic;

namespace _2._A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            string resource = Console.ReadLine();
            Dictionary<string, int> resources = new Dictionary<string, int>();
            while (resource.ToLower()!="stop")
            {
                int quantity = int.Parse(Console.ReadLine());
                if (resources.ContainsKey(resource))
                {
                    resources[resource] += quantity;
                }
                else
                {
                resources.Add(resource,quantity);
                }
                resource = Console.ReadLine();
            }
            foreach (var x in resources)
            {
                Console.WriteLine($"{x.Key} -> {x.Value}");
            }
        }
    }
}
