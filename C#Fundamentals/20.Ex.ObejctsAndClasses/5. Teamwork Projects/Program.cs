using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Teamwork_Projects
{
    public class Team
    {
        public Team(string teamName, string creator)
        {
            this.TeamName = teamName;
            this.Creator = creator;
            Members = new List<string>();
        }
        public string TeamName { get; set; }
        public string Creator { get; set; }
        public List<string> Members { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Team> teams = new List<Team>();
            bool isTeamExist = false;
            bool isCreatorExist = false;
            for (int i = 0; i < n; i++)
            {
                isTeamExist = false;
                isCreatorExist = false;
                string[] createCommand = Console.ReadLine().Split("-");
                foreach (var x in teams)
                {
                    if (x.Creator == createCommand[0])
                    {
                        isCreatorExist = true;
                    }
                    if (x.TeamName == createCommand[1])
                    {
                        isTeamExist = true;
                    }
                }
                if (!isTeamExist)
                {
                    if (!isCreatorExist)
                    {
                        Team currTeam = new Team(createCommand[1], createCommand[0]);
                        teams.Add(currTeam);
                        Console.WriteLine($"Team {createCommand[1]} has been created by {createCommand[0]}!");
                    }
                    else
                    {
                        Console.WriteLine($"{createCommand[0]} cannot create another team!");
                    }
                }
                else
                {
                    Console.WriteLine($"Team {createCommand[1]} was already created!");
                }
            }
            //foreach (var x in teams)
            //{
            //    x.Members.Add(x.Creator);
            //}
            string[] c = Console.ReadLine().Split("->");
            while (c[0].ToLower()!="end of assignment")
            {
                isTeamExist = teams.Select(x => x.TeamName).Contains(c[1]);
                bool isMemberExist = false;
                foreach (var x in teams)
                {
                    if (x.Creator == c[0])
                    {
                        isMemberExist = true;
                    }
                    foreach (var z in x.Members)
                    {
                        if (z == c[0])
                        {
                            isMemberExist = true;
                        }
                    }
                }
                if (isTeamExist)
                {
                    if (!isMemberExist)
                    {
                        foreach (var x in teams)
                        {
                            if (x.TeamName == c[1])
                            {
                                x.Members.Add(c[0]);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Member {c[0]} cannot join team {c[1]}!");
                    }
                }
                else
                {
                    Console.WriteLine($"Team {c[1]} does not exist!");
                }
                c = Console.ReadLine().Split("->");
            }
            List<Team> disbandTeams = new List<Team>();
            foreach (var x in teams.OrderByDescending(x => x.Members.Count).ThenBy(x => x.TeamName))
            {
                if (x.Members.Count==0)
                {
                    disbandTeams.Add(x);
                }
                if (x.Members.Count>0)
                {
                    Console.WriteLine(x.TeamName);
                    Console.WriteLine($"- {x.Creator}");
                    foreach (var z in x.Members.OrderBy(x => x))
                    {
                        Console.WriteLine($"-- {z}");
                    }
                }
            }
            Console.WriteLine("Teams to disband:");
            foreach (var x in disbandTeams.OrderBy(x => x.TeamName))
            {
                Console.WriteLine(x.TeamName);
            }
        }
    }
}
