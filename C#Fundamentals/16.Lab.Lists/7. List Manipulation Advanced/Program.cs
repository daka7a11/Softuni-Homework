using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._List_Manipulation_Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            string[] command = Console.ReadLine().Split();
            bool isChanged = false;
            while (command[0].ToLower() != "end")
            {
                if (command[0].ToLower() == "add")
                {
                    numbers.Add(int.Parse(command[1]));
                    isChanged = true;
                }
                else if (command[0].ToLower() == "remove")
                {
                    numbers.Remove(int.Parse(command[1]));
                    isChanged = true;
                }
                else if (command[0].ToLower() == "removeat")
                {
                    numbers.RemoveAt(int.Parse(command[1]));
                    isChanged = true;
                }
                else if (command[0].ToLower() == "insert")
                {
                    numbers.Insert(int.Parse(command[2]), int.Parse(command[1]));
                    isChanged = true;
                }

                // EX 7 ---------------------------------------------------------------

                else if (command[0].ToLower() == "contains")
                {
                    Console.WriteLine(numbers.Contains(int.Parse(command[1])) ? "Yes" : "No such number");
                }
                else if (command[0].ToLower() == "printeven")
                {
                    Console.WriteLine(string.Join(" ", numbers.Where(x => x % 2 == 0)));
                }
                else if (command[0].ToLower() == "printodd")
                {
                    Console.WriteLine(string.Join(" ", numbers.Where(x => x % 2 != 0)));
                }
                else if (command[0].ToLower() == "getsum")
                {
                    Console.WriteLine(numbers.Sum());
                }
                else if (command[0].ToLower() == "filter")
                {
                    if (command[1] == "<")
                    {
                        Console.WriteLine(string.Join(" ", numbers.Where(x => x < int.Parse(command[2]))));
                    }
                    else if (command[1] == ">")
                    {
                        Console.WriteLine(string.Join(" ", numbers.Where(x => x > int.Parse(command[2]))));
                    }
                    else if (command[1] == ">=")
                    {
                        Console.WriteLine(string.Join(" ", numbers.Where(x => x >= int.Parse(command[2]))));
                    }
                    else if (command[1] == "<=")
                    {
                        Console.WriteLine(string.Join(" ", numbers.Where(x => x <= int.Parse(command[2]))));
                    }
                }
                command = Console.ReadLine().Split();
            }
            if (isChanged)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }

        }
    }
}
