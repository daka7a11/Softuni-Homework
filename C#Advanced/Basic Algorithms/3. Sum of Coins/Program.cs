using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Sum_of_Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new char[] {' ',','}, StringSplitOptions.RemoveEmptyEntries);
            int[] coins = new int[input.Length - 1];
            for (int i = 1; i < input.Length; i++)
            {
                coins[i - 1] = int.Parse(input[i]);
            }
            coins = coins.OrderByDescending(x => x).ToArray();
            input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            long sum = long.Parse(input[1]);
            int coinNumber = 0;
            Dictionary<long,long> chooseCoins = new Dictionary<long, long>();
            foreach (var coin in coins)
            {
                while (coin<=sum)
                {
                    if (!chooseCoins.ContainsKey(coin))
                    {
                        chooseCoins.Add(coin, 0);
                    }
                    coinNumber++;
                    sum -= coin;
                    chooseCoins[coin]++;
                }
            }
            if (sum == 0)
            {
                Console.WriteLine($"Number of coins to take: {coinNumber}");
                foreach (var coin in chooseCoins)
                {
                    Console.WriteLine($"{coin.Value} coin(s) with value {coin.Key}");
                }
            }
            else
            {
                Console.WriteLine("Error");
            }
        }
    }
}
