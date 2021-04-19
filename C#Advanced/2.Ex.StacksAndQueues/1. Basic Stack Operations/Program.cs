using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _1._Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nsx = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>(numbers);
            int n = nsx[0];
            int s = nsx[1];
            int x = nsx[2];
            for (int i = 0; i < s; i++)
            {
                stack.Pop();
            }
            int minElement = int.MaxValue;
            bool isContains = false;
            while (stack.Count>0)
            {
                int currElement = stack.Pop();
                if (currElement==x)
                {
                    Console.WriteLine("true");
                    isContains = true;
                    break;
                }
                else
                {
                    if (minElement>currElement)
                    {
                        minElement = currElement;
                    }
                }
            }
            if (!isContains)
            {
                if (minElement!=int.MaxValue)
                {
                Console.WriteLine(minElement);
                }
                else
                {
                    Console.WriteLine(0);
                }
            }
        }
    }
}
