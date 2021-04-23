using System;

namespace GamingStore
{
    class Program
    {
        static void Main(string[] args)
        {
            double balance = double.Parse(Console.ReadLine());
            double totalSpent = balance;
            string game = Console.ReadLine();
            string game1 = game.ToLower();
            while (game1!="game time")
            {
                if (game1=="outfall 4")
                {
                    if (balance<39.99)
                    {
                        Console.WriteLine("Too Expensive");
                    }
                    else
                    {
                        balance -= 39.99;
                        Console.WriteLine($"Bought {game}");
                    }
                }
                else if (game1 == "cs: og")
                {
                    if (balance < 15.99)
                    {
                        Console.WriteLine("Too Expensive");
                    }
                    else
                    {
                        balance -= 15.99;
                        Console.WriteLine($"Bought {game}");
                    }
                }
                else if (game1 == "zplinter zell")
                {
                    if (balance < 19.99)
                    {
                        Console.WriteLine("Too Expensive");
                    }
                    else
                    {
                        balance -= 19.99;
                        Console.WriteLine($"Bought {game}");
                    }
                }
                else if (game1 == "honored 2")
                {
                    if (balance < 59.99)
                    {
                        Console.WriteLine("Too Expensive");
                    }
                    else
                    {
                        balance -= 59.99;
                        Console.WriteLine($"Bought {game}");
                    }
                }
                else if (game1 == "roverwatch")
                {
                    if (balance < 29.99)
                    {
                        Console.WriteLine("Too Expensive");
                    }
                    else
                    {
                        balance -= 29.99;
                        Console.WriteLine($"Bought {game}");
                    }
                }
                else if (game1 == "roverwatch origins edition")
                {
                    if (balance < 39.99)
                    {
                        Console.WriteLine("Too Expensive");
                    }
                    else
                    {
                        balance -= 39.99;
                        Console.WriteLine($"Bought {game}");
                    }
                }
                else
                {
                    Console.WriteLine("Not Found");
                }
                if (balance==0)
                {
                    Console.WriteLine("Out of money!");
                    break;
                }
                game = Console.ReadLine();
                game1 = game.ToLower();
            }
            if (game1=="game time")
            {
                Console.WriteLine($"Total spent: ${totalSpent-balance:F2}. Remaining: ${balance:F2}");
            }
        }
    }
}
