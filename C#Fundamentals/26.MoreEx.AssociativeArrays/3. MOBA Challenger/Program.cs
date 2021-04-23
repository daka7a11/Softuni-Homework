using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._MOBA_Challenger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> players = new Dictionary<string, Dictionary<string, int>>();
            string[] input = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
            while (input[0].ToLower() != "season end")
            {
                if (input.Length == 3)
                {
                    string username = input[0];
                    string position = input[1];
                    int skill = int.Parse(input[2]);

                    if (players.ContainsKey(username))
                    {
                        if (players[username].ContainsKey(position))
                        {
                            if (players[username][position] < skill)
                            {
                                players[username][position] = skill;
                            }
                        }
                        else
                        {
                            players[username].Add(position, skill);
                        }
                    }
                    else
                    {
                        players.Add(username, new Dictionary<string, int>());
                        players[username].Add(position, skill);
                    }
                }
                else if (input.Length == 1)
                {
                    input = input[0].Split(" vs ", StringSplitOptions.RemoveEmptyEntries);
                    string firstPlayer = input[0];
                    string secondPlayer = input[1];
                    if (players.ContainsKey(firstPlayer) && players.ContainsKey(secondPlayer))
                    {
                        int firstPlayerTotalSkillPoints = players[firstPlayer].Values.Sum();
                        int secondPlayerTotalSkillPoints = players[secondPlayer].Values.Sum();
                        bool isRemoved = false;
                        foreach (var first in players[firstPlayer])
                        {
                            if (isRemoved)
                            {
                                break;
                            }
                            foreach (var second in players[secondPlayer])
                            {
                                if (first.Key == second.Key)
                                {
                                    if (firstPlayerTotalSkillPoints > secondPlayerTotalSkillPoints)
                                    {
                                        players.Remove(secondPlayer);
                                        isRemoved = true;
                                        break;
                                    }
                                    else if (firstPlayerTotalSkillPoints < secondPlayerTotalSkillPoints)
                                    {
                                        players.Remove(firstPlayer);
                                        isRemoved = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                input = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
            }
            foreach (var player in players.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{player.Key}: {player.Value.Values.Sum()} skill");
                foreach (var role in player.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"- {role.Key} <::> {role.Value}");
                }
            }
        }
    }
}