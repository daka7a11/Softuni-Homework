using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();
            string[] input = Console.ReadLine().Split(":");
            while (input[0].ToLower() != "end of contests")
            {
                if (contests.ContainsKey(input[0]) == false)
                {
                    contests.Add(input[0], input[1]);
                }
                input = Console.ReadLine().Split(":");
            }
            Dictionary<string, Dictionary<string, int>> profiles = new Dictionary<string, Dictionary<string, int>>();
            input = Console.ReadLine().Split("=>");
            while (input[0].ToLower()!="end of submissions")
            {
                string currContest = input[0];
                string currPass = input[1];
                string currUser = input[2];
                int currPoints = int.Parse(input[3]);
                if (contests.ContainsKey(currContest))
                {
                    if (contests[currContest]==currPass)
                    {
                        if (profiles.ContainsKey(currUser))
                        {
                            if (profiles[currUser].ContainsKey(currContest))
                            {
                                if (profiles[currUser][currContest]<currPoints)
                                {
                                    profiles[currUser][currContest] = currPoints;
                                }
                            }
                            else
                            {
                                profiles[currUser].Add(currContest,currPoints);
                            }
                        }
                        else
                        {
                            profiles.Add(currUser, new Dictionary<string, int>());
                            profiles[currUser].Add(currContest,currPoints);
                        }
                    }
                    else
                    {
                        input = Console.ReadLine().Split("=>");
                        continue;
                    }
                }
                else
                {
                    input = Console.ReadLine().Split("=>");
                    continue;
                }
                input = Console.ReadLine().Split("=>");
            }
            string bestName = string.Empty;
            int bestSum = 0;
            foreach (var profile in profiles)
            {
                string currName = profile.Key;
                int currSum = profile.Value.Values.Sum();
                if (currSum>bestSum)
                {
                    bestName = currName;
                    bestSum = currSum;
                }
            }
            Console.WriteLine($"Best candidate is {bestName} with total {bestSum} points.");
            Console.WriteLine("Ranking: ");
            foreach (var profile in profiles.OrderBy(x => x.Key))
            {
                Console.WriteLine(profile.Key);
                foreach (var contest in profile.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
