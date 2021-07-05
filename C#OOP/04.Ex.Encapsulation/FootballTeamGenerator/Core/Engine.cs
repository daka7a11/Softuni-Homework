using FootballTeamGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator.Core
{
    public class Engine
    {
        private const string INVALID_TEAM_EXC_MSG = "Team {0} does not exist.";
        private ICollection<Team> teams;
        public Engine()
        {
            teams = new List<Team>();
        }
        public void Run()
        {
            string[] input = Console.ReadLine().Split(';');
            while (input[0].ToLower() != "end")
            {
                try
                {
                    string command = input[0].ToLower();
                    string teamName = input[1];
                    if (command == "team")
                    {
                        CreateTeam(teamName);
                    }
                    else if (command == "add")
                    {
                        string playerName = input[2];
                        int endurance = int.Parse(input[3]);
                        int sprint = int.Parse(input[4]);
                        int dribble = int.Parse(input[5]);
                        int passing = int.Parse(input[6]);
                        int shooting = int.Parse(input[7]);

                        ValidateTeamExists(teamName);
                        Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);

                        Team team = teams.First(x => x.Name == teamName);
                        team.AddPlayer(player);
                    }
                    else if (command == "remove")
                    {
                        string playerNameToRemove = input[2];

                        ValidateTeamExists(teamName);
                        Team team = teams.First(x => x.Name == teamName);
                        team.RemovePlayer(playerNameToRemove);
                    }
                    else if (command == "rating")
                    {
                        ValidateTeamExists(teamName);
                        Team team = teams.First(x => x.Name == teamName);
                        Console.WriteLine(RatingTeam(teamName));
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                input = Console.ReadLine().Split(';');
            }
        }
        private void CreateTeam(string teamName)
        {
            teams.Add(new Team(teamName));
        }
        private void RemovePlayerFromTeam(string teamName, string playerName)
        {
            ValidateTeamExists(teamName);
            Team team = teams.First(x => x.Name == teamName);
            team.RemovePlayer(playerName);
        }
        private void AddPlayerToTeam(string teamName, Player player)
        {
            ValidateTeamExists(teamName);
            Team team = teams.First(x => x.Name == teamName);
            team.AddPlayer(player);
        }
        private string RatingTeam(string teamName)
        {
            ValidateTeamExists(teamName);
            Team team = teams.First(x => x.Name == teamName);
            return $"{team.Name} - {team.Rating}";
        }
        private void ValidateTeamExists(string teamName)
        {
            Team team = teams.FirstOrDefault(x => x.Name == teamName);
            if (team == null)
            {
                throw new ArgumentException(String.Format(INVALID_TEAM_EXC_MSG, teamName));
            }
        }
    }
}
