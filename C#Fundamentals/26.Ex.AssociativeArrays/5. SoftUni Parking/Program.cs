using System;
using System.Collections.Generic;

namespace _5._SoftUni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, string> users = new Dictionary<string, string>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                if (input[0].ToLower()=="register")
                {
                    if (!users.ContainsKey(input[1]))
                    {
                        users.Add(input[1],input[2]);
                        Console.WriteLine($"{input[1]} registered {input[2]} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {users[input[1]]}");
                    }
                }
                else if (input[0].ToLower()=="unregister")
                {
                    if (!users.ContainsKey(input[1]))
                    {
                        Console.WriteLine($"ERROR: user {input[1]} not found");
                    }
                    else
                    {
                        users.Remove(input[1]);
                        Console.WriteLine($"{input[1]} unregistered successfully");
                    }
                }
            }
            foreach (var x in users)
            {
                Console.WriteLine($"{x.Key} => {x.Value}");
            }
        }
    }
}
