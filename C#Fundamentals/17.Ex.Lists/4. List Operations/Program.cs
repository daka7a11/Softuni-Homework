using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._List_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string[] input = Console.ReadLine().Split();
            while (input[0].ToLower() != "end")
            {
                if (input[0].ToLower() == "add")
                {
                    numbers.Add(int.Parse(input[1]));
                }
                else if (input[0].ToLower() == "insert")
                {
                    if ((int.Parse(input[2]) >= 0) && ((int.Parse(input[2])) < numbers.Count))
                    {
                        numbers.Insert(int.Parse(input[2]), int.Parse(input[1]));
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }
                }
                else if (input[0].ToLower() == "remove")
                {
                    if ((int.Parse(input[1])) >= 0 && ((int.Parse(input[1])) < numbers.Count))
                    {
                        numbers.RemoveAt(int.Parse(input[1]));
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }
                }
                else if (input[0].ToLower() == "shift")
                {
                    if (input[1].ToLower() == "left")
                    {
                        for (int i = 0; i < int.Parse(input[2]); i++)
                        {
                            numbers.Add(numbers[0]);
                            numbers.RemoveAt(0);
                        }
                    }
                    else if (input[1].ToLower() == "right")
                    {
                        for (int i = 0; i < int.Parse(input[2]); i++)
                        {
                            numbers.Insert(0, numbers[numbers.Count - 1]);
                            numbers.RemoveAt(numbers.Count - 1);
                        }
                    }

                }
                input = Console.ReadLine().Split();
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
