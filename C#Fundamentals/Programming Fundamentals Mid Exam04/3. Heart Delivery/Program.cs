using System;
using System.Linq;

namespace _3._Heart_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] houses = Console.ReadLine()
                .Split("@")
                .Select(int.Parse)
                .ToArray();

            int cupidPosition = 0;
            string[] jump = Console.ReadLine().Split();
            while (jump[0].ToLower() != "love!")
            {
                cupidPosition += int.Parse(jump[1]);
                if (cupidPosition >= houses.Length)
                {
                    cupidPosition = 0;
                }
                if (houses[cupidPosition] == 0)
                {
                    Console.WriteLine($"Place {cupidPosition} already had Valentine's day.");
                }
                else
                {
                    houses[cupidPosition] -= 2;
                    if (houses[cupidPosition]==0)
                    {
                        Console.WriteLine($"Place {cupidPosition} has Valentine's day.");
                    }
                }
                jump = Console.ReadLine().Split();
            }
            Console.WriteLine($"Cupid's last position was {cupidPosition}.");
            int housesHadValentinesDay = 0;
            foreach (var x in houses)
            {
                if (x==0)
                {
                    housesHadValentinesDay++;
                }
            }
            if (housesHadValentinesDay==houses.Length)
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Cupid has failed {Math.Abs(housesHadValentinesDay-houses.Length)} places.");
            }
        }
    }
}
