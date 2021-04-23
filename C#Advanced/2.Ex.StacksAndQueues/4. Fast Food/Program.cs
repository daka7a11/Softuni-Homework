using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _4._Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantityOfFood = int.Parse(Console.ReadLine());
            int[] orders = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>(orders);
            Console.WriteLine(queue.Max());
            while (queue.Count > 0)
            {
                if (queue.Peek() <= quantityOfFood)
                {
                    quantityOfFood-= queue.Dequeue();
                }
                else
                {
                    break;
                }
            }
            if (queue.Count==0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
            Console.Write("Orders left: ");
            Console.Write(string.Join(" ",queue));
            }
        }
    }
}
