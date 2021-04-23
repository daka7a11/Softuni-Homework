using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Shopping_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> grocerise = Console.ReadLine()
                .Split("!",StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            string[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            while (string.Join(" ",input).ToLower()!="go shopping!")
            {
                if (input[0].ToLower()=="urgent")
                {
                    if (!grocerise.Contains(input[1]))
                    {
                        grocerise.Insert(0, input[1]);
                    }
                }
                else if (input[0].ToLower() == "unnecessary")
                {
                    if (grocerise.Contains(input[1]))
                    {
                        grocerise.Remove(input[1]);
                    }
                }
                else if (input[0].ToLower() == "correct")
                {
                    if (grocerise.Contains(input[1]))
                    {
                        int indexOfOldItem = grocerise.FindIndex(x => x == input[1]);
                        grocerise[indexOfOldItem] = input[2];
                    }
                }
                else if (input[0].ToLower() == "rearrange")
                {
                    if (grocerise.Contains(input[1]))
                    {
                        grocerise.Remove(input[1]);
                        grocerise.Add(input[1]);
                    }
                }
                input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            Console.WriteLine(string.Join(", ",grocerise));
        }
    }
}
