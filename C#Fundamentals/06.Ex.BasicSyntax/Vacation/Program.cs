using System;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            string day = Console.ReadLine();
            type = type.ToLower();
            day = day.ToLower();
            double total = 0;
            if (type == "students")
            {
                if (day == "friday")
                {
                    total = people * 8.45;
                }
                else if (day == "saturday")
                {
                    total = people * 9.80;
                }
                else if (day == "sunday")
                {
                    total = people * 10.46;
                }
                if (people >= 30)
                {
                    total -= total * 0.15;
                }
            }
            else if (type == "business")
            {
                if (day == "friday")
                {
                    total = people * 10.90;
                    if (people >= 100)
                    {
                        total -=10*10.90;
                    }
                }
                else if (day == "saturday")
                {
                    total = people * 15.60;
                    if (people >= 100)
                    {
                        total -=10*15.60;
                    }
                }
                else if (day == "sunday")
                {
                    total = people * 16;
                    if (people >= 100)
                    {
                        total -=10*16;
                    }
                }
            }
            else if (type == "regular")
            {
                if (day == "friday")
                {
                    total = people * 15;
                }
                else if (day == "saturday")
                {
                    total = people * 20;
                }
                else if (day == "sunday")
                {
                    total = people * 25;
                }
                if (people >= 10&&people<=20)
                {
                    total -=total*0.05;
                }
            }
            Console.WriteLine($"Total price: {total:F2}");
        }
    }
}
