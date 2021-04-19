using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _5._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clothes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int capacityOfaRack = int.Parse(Console.ReadLine());
            int rackCount = 1;
            Stack<int> stack = new Stack<int>(clothes);
            int rack = 0;
            while (stack.Count>0)
            {
                int currItem = stack.Peek();
                if ((rack+currItem)>capacityOfaRack)
                {
                    rackCount++;
                    rack = 0;
                    rack += stack.Pop();
                }
                else
                {
                    rack += stack.Pop();
                }
            }
            Console.WriteLine(rackCount);
        }
    }
}
