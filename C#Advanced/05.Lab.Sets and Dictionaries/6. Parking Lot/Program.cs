using System;
using System.Collections.Generic;

namespace _6._Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> carNumbers = new HashSet<string>();
            string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            while (input[0].ToLower() != "end")
            {
                string currCarNumber = input[1];
                if (input[0].ToLower() == "in")
                {
                    carNumbers.Add(currCarNumber);
                }
                else if (input[0].ToLower() == "out")
                {
                    carNumbers.Remove(currCarNumber);
                }
                input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            }
            if (carNumbers.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                foreach (var car in carNumbers)
                {
                    Console.WriteLine(car);
                }
            }
        }
    }
}