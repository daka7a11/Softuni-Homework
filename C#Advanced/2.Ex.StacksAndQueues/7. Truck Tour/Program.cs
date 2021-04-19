using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _7._Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfPumps = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>();
            for (int i = 0; i < numOfPumps; i++)
            {
                string input = Console.ReadLine();
                queue.Enqueue(input + " " + i);
            }
            int totalFuel = 0;
            for (int i = 0; i < numOfPumps; i++)
            {
                string currInfo = queue.Dequeue();
                int[] splitedInfo = currInfo.Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int fuel = splitedInfo[0];
                int distance = splitedInfo[1];
                int index = splitedInfo[2];
                totalFuel += fuel;
                if (totalFuel>=distance)
                {
                    totalFuel -= distance;
                }
                else
                {
                    totalFuel = 0;
                    i=-1;
                }
                queue.Enqueue(currInfo);
            }
            string[] result = queue.Peek().Split().ToArray();
            Console.WriteLine(result[2]);
        }
    }
}
