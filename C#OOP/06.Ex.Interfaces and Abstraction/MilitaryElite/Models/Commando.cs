using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(int id, string firstName, string lastName, decimal salary, 
            SoldiersCorpsEnum corps,ICollection<IMission> missions) 
            : base(id, firstName, lastName, salary, corps)
        {
            Missions = missions;
        }

        public ICollection<IMission> Missions { get; private set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {Corps}");
            sb.AppendLine($"Missions:");
            foreach (var mission in Missions)
            {
                sb.AppendLine("  " + mission.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
