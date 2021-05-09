using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Vlogger> listOfVloggers = new List<Vlogger>();
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            while (input[0].ToLower() != "statistics")
            {
                if (input[1].ToLower() == "joined")
                {
                    string firstVlogger = input[0];
                    if (!IsVloggerExist(listOfVloggers, firstVlogger))
                    {
                        listOfVloggers.Add(new Vlogger() { Name = firstVlogger });
                    }
                }
                else if (input[1].ToLower() == "followed")
                {
                    string firstVlogger = input[0];
                    string secondVlogger = input[2];
                    if (IsVloggerExist(listOfVloggers, firstVlogger) && IsVloggerExist(listOfVloggers, secondVlogger) && firstVlogger != secondVlogger)
                    {
                        if (!IsFollowingExist(listOfVloggers, firstVlogger, secondVlogger))
                        {
                            foreach (var vlogger in listOfVloggers)
                            {
                                if (vlogger.Name == firstVlogger)
                                {
                                    vlogger.Followings.Add(secondVlogger);
                                }
                                else if (vlogger.Name == secondVlogger)
                                {
                                    vlogger.Followers.Add(firstVlogger);
                                }
                            }
                        }
                    }

                }
                input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            int count = 1;
            Console.WriteLine($"The V-Logger has a total of {listOfVloggers.Count} vloggers in its logs.");
            foreach (var vlogger in listOfVloggers.OrderByDescending(x => x.Followers.Count).ThenBy(x => x.Followings.Count))
            {
                Console.WriteLine($"{count}. {vlogger.Name} : {vlogger.Followers.Count} followers, {vlogger.Followings.Count} following");
                if (count==1)
                {
                    foreach (var follower in vlogger.Followers.OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
                count++;
            }
        }
        static bool IsVloggerExist(List<Vlogger> vloggers, string name)
        {
            foreach (var vlogger in vloggers)
            {
                if (vlogger.Name == name)
                {
                    return true;
                }
            }
            return false;
        }
        static bool IsFollowingExist(List<Vlogger> vloggers, string firstVlogger, string secondVlogger)
        {
            foreach (var vlogger in vloggers)
            {
                if (vlogger.Name == firstVlogger)
                {
                    foreach (var following in vlogger.Followings)
                    {
                        if (following == secondVlogger)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
    public class Vlogger
    {
        public Vlogger()
        {
            Followers = new List<string>();
            Followings = new List<string>();
        }
        public string Name { get; set; }
        public List<string> Followers { get; set; }
        public List<string> Followings { get; set; }
    }
}
