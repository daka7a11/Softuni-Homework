using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public interface IMission
    {
        public string CodeName { get;}
        public MissionStateEnum State { get;}
        void CompleteMission(string codeName);
    }
}
