using System.Collections.Generic;

namespace MilitaryElite
{
    public interface ICommando
    {
        public ICollection<IMission> Missions { get;}
    }
}
