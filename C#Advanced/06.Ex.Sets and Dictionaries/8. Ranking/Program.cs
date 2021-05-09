using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> candidates = new Dictionary<string, Dictionary<string, int>>();
            string[] input = Console.ReadLine().Split(":",StringSplitOptions.RemoveEmptyEntries);
            while (input[0].ToLower()!="end of contests")
            {
                string contest = input[0];
                string password = input[1];
                contests.Add(contest,password);
                input = Console.ReadLine().Split(":", StringSplitOptions.RemoveEmptyEntries);
            }
            input = Console.ReadLine().Split("=>",StringSplitOptions.RemoveEmptyEntries);
            while (input[0].ToLower()!="end of submissions")
            {
                string content = input[0];
                string password = input[1];
                string name = input[2];
                int points = int.Parse(input[3]);
                if (contests.ContainsKey(content)) // IsContentExist
                {
                    if (contests[content]==password) // IsPasswordCorrect
                    {
                        if (candidates.ContainsKey(name)) // IsCandidateExist
                        {
                            if (candidates[name].ContainsKey(content))
                            {
                                if (candidates[name][content]<points)
                                {
                                    candidates[name][content] = points;
                                }
                            }
                            else
                            {
                                candidates[name].Add(content, points);
                            }
                        }
                        else
                        {
                            candidates.Add(name, new Dictionary<string, int>());
                            candidates[name].Add(content,points);
                        }
                    }
                }
                input = Console.ReadLine().Split("=>", StringSplitOptions.RemoveEmptyEntries);
            }
            string bestCandidate = string.Empty;
            int bestPoints = 0;
            foreach (var candidate in candidates)
            {
                int totalPoints = 0;
                foreach (var content in candidate.Value)
                {
                    totalPoints += content.Value;
                }
                if (totalPoints>bestPoints)
                {
                    bestCandidate = candidate.Key;
                    bestPoints = totalPoints;
                }
            }
            Console.WriteLine($"Best candidate is {bestCandidate} with total {bestPoints} points.");
            Console.WriteLine("Ranking:");
            foreach (var candidate in candidates.OrderBy(x => x.Key))
            {
                Console.WriteLine(candidate.Key);
                foreach (var content in candidate.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {content.Key} -> {content.Value}");
                }
            }
        }
    }
}
