using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Missions : IMission
    {
        public Missions(string codeName, MissionStateEnum missionStateEnum)
        {
            CodeName = codeName;
            State = missionStateEnum;
        }
        public string CodeName { get; private set; }

        public MissionStateEnum State { get; private set; }

        public void CompleteMission(string codeName)
        {
            State = MissionStateEnum.Finished;
        }
        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {State}";
        }
    }
}
