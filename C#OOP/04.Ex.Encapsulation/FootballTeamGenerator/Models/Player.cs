using FootballTeamGenerator.Common;
using System;

namespace FootballTeamGenerator.Models
{
    public class Player
    {
        private const string INVALID_STAT_EXC_MSG = "{0} should be between 0 and 100.";

        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
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
        public int Endurance
        {
            get
            {
                return endurance;
            }
            private set
            {
                ValidateStat(nameof(Endurance), value);
                endurance = value;
            }
        }
        public int Sprint
        {
            get
            {
                return sprint;
            }
            private set
            {
                ValidateStat(nameof(Sprint), value);
                sprint = value;
            }
        }
        public int Dribble
        {
            get
            {
                return dribble;
            }
            private set
            {
                ValidateStat(nameof(Dribble), value);
                dribble = value;
            }
        }
        public int Passing
        {
            get
            {
                return passing;
            }
            private set
            {
                ValidateStat(nameof(Passing), value);
                passing = value;
            }
        }
        public int Shooting
        {
            get
            {
                return shooting;
            }
            private set
            {
                ValidateStat(nameof(Shooting), value);
                shooting = value;
            }
        }

        private void ValidateStat(string statName, int value)
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException(String.Format(INVALID_STAT_EXC_MSG,statName));
            }
        }

        public double SkillLevel()
        {
            return (Endurance+Sprint+Dribble+Passing+Shooting)/5.00;
        }
    }
}
