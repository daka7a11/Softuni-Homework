using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Cards_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> deckOne = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToList();
            List<int> deckTwo = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToList();
            while (deckOne.Count != 0 && deckTwo.Count != 0)
            {
                int oneCard = deckOne[0];
                int twoCard = deckTwo[0];
                if (oneCard==twoCard)
                {
                    deckOne.RemoveAt(0);
                    deckTwo.RemoveAt(0);
                }
                else if (oneCard > twoCard)
                {
                    deckOne.Add(oneCard);
                    deckOne.Add(twoCard);
                    deckOne.RemoveAt(0);
                    deckTwo.RemoveAt(0);
                }
                else if (oneCard < twoCard)
                {
                    deckTwo.Add(twoCard);
                    deckTwo.Add(oneCard);
                    deckTwo.RemoveAt(0);
                    deckOne.RemoveAt(0);
                }
            }
            if (deckOne.Count==0)
            {
                Console.WriteLine($"Second player wins! Sum: {deckTwo.Sum()}");
            }
            else
            {
                Console.WriteLine($"First player wins! Sum: {deckOne.Sum()}");

            }
        }
    }
}
