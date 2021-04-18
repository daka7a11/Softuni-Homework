using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Judge
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> students = new Dictionary<string, int>();
            Dictionary<string, Dictionary<string, int>> contests = new Dictionary<string, Dictionary<string, int>>();

            string[] input = Console.ReadLine().Split(" -> ");
            while (input[0].ToLower()!="no more time")
            {
                string currName = input[0];
                string currContest = input[1];
                int points = int.Parse(input[2]);
                if (contests.ContainsKey(currContest))
                {
                    if (contests[currContest].ContainsKey(currName))
                    {
                        if (contests[currContest][currName]<points)
                        {
                            contests[currContest][currName] = points;
                        }
                    }
                    else
                    {
                        contests[currContest].Add(currName,points);
                    }
                }
                else
                {
                    contests.Add(currContest, new Dictionary<string, int>());
                    contests[currContest].Add(currName,points);
                }
                input = Console.ReadLine().Split(" -> ");
            }
            foreach (var contest in contests)
            {
                foreach (var user in contest.Value)
                {
                    if (students.ContainsKey(user.Key))
                    {
                        students[user.Key] += user.Value;
                    }
                    else
                    {
                        students.Add(user.Key, user.Value);
                    }
                }
            }
            foreach (var contest in contests)
            {
                Console.WriteLine($"{contest.Key}: {contest.Value.Count} participants");
                int count = 1;
                foreach (var user in contest.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{count++}. {user.Key} <::> {user.Value}");
                }
            }
            Console.WriteLine("Individual standings:");
            int lastCount = 1;
            foreach (var student in students.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{lastCount++}. {student.Key} -> {student.Value}");
            }
        }
    }
}
