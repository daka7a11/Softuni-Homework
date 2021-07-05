using FootballTeamGenerator.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator.Models
{
    public class Team
    {
        private const string INVALID_PLAYER_EXC_MSG = "Player {0} is not in {1} team.";
        private string name;
        private ICollection<Player> players;

        public Team(string name)
        {
            Name = name;
            players = new List<Player>();
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(GlobalConstants.INVALID_NAME_EXC_MSG);
                }
                name = value;
            }
        }
        public int Rating
        {
            get
            {
                return GetTeamRating();
            }
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }
        public void RemovePlayer(string playerName)
        {
            Player playerToRemove = players.FirstOrDefault(x => x.Name == playerName);
            if (playerToRemove == null)
            {
                throw new ArgumentException(String.Format(INVALID_PLAYER_EXC_MSG, playerName, Name));
            }
            players.Remove(playerToRemove);
        }
        private int GetTeamRating()
        {
            if (players.Count>0)
            {
                return (int)Math.Round(players.Average(x => x.SkillLevel()));
            }
            return 0;
        }

    }
}
