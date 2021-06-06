using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> players;
        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            players = new List<Player>();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count {get  => players.Count; }

        public void AddPlayer(Player player)
        {
            if (players.Count < Capacity)
            {
                players.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            if (players.Any(x => x.Name == name))
            {
                players.Remove(players.First(x => x.Name == name));
                return true;
            }
            return false;
        }

        public void PromotePlayer(string name)
        {
            Player player = players.FirstOrDefault(x => x.Name == name);
            if (player!=null)
            {
                player.Rank = "Member";
            }
        }
        public void DemotePlayer(string name)
        {
            Player player = players.FirstOrDefault(x => x.Name == name);
            if (player != null)
            {
                player.Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string inputClass)
        {
            Player[] kickedPlayers = players.Where(x => x.Class == inputClass).ToArray();
            foreach (var kickedPlayer in kickedPlayers)
            {
                players.Remove(kickedPlayer);
            }
            return kickedPlayers;
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Players in the guild: {Name}");
            foreach (var player in players)
            {
                result.AppendLine(player.ToString());
            }
            return result.ToString().TrimEnd();
        }
    }
}
