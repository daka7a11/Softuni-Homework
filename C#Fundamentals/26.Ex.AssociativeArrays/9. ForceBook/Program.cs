using System;
using System.Collections.Generic;
using System.Linq;

namespace _9._ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> profiles = new Dictionary<string, List<string>>();
            string input;
            while ((input = Console.ReadLine())?.ToLower() != "lumpawaroo")
            {
                string[] cmdByLine = input.Split(" | ", StringSplitOptions.RemoveEmptyEntries);
                string[] cmdByArrow = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                if (cmdByLine.Length == 2)  // Side | User
                {
                    bool isUserExist = CheckIfUserExist(cmdByLine[1], profiles);
                    if (isUserExist == false && profiles.ContainsKey(cmdByLine[0]))
                    {
                        profiles[cmdByLine[0]].Add(cmdByLine[1]);
                    }
                    else if (isUserExist == false && profiles.ContainsKey(cmdByLine[0]) == false)
                    {
                        profiles.Add(cmdByLine[0], new List<string> { cmdByLine[1] });
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (cmdByArrow.Length == 2) // User | Side
                {
                    bool isUserExist = CheckIfUserExist(cmdByArrow[0], profiles);
                    if (isUserExist)
                    {
                        foreach (var x in profiles)
                        {
                            if (x.Value.Contains(cmdByArrow[0]))
                            {
                                x.Value.Remove(cmdByArrow[0]);
                                break;
                            }
                        }
                        if (profiles.ContainsKey(cmdByArrow[1]))
                        {
                            profiles[cmdByArrow[1]].Add(cmdByArrow[0]);
                        }
                        else 
                        {
                            profiles.Add(cmdByArrow[1], new List<string> { cmdByArrow[0]});
                        }
                    }
                    else
                    {
                        if (profiles.ContainsKey(cmdByArrow[1]))
                        {
                            profiles[cmdByArrow[1]].Add(cmdByArrow[0]);
                        }
                        else
                        {
                            profiles.Add(cmdByArrow[1], new List<string> { cmdByArrow[0] });
                        }
                    }
                    Console.WriteLine($"{cmdByArrow[0]} joins the {cmdByArrow[1]} side!");
                }
            }
            foreach (var profile in profiles.OrderByDescending(c => c.Value.Count).ThenBy(n => n.Key))
            {
                if (profile.Value.Count==0)
                {
                    continue;
                }
                Console.WriteLine($"Side: {profile.Key}, Members: {profile.Value.Count}");
                foreach (var person in profile.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"! {person}");
                }
            }
        }
        static bool CheckIfUserExist(string user, Dictionary<string, List<string>> profiles)
        {
            foreach (var x in profiles)
            {
                foreach (var z in x.Value)
                {
                    if (z == user)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}