using System;

namespace Raiding.Models
{
    public class Rogue : BaseHero
    {
        public Rogue(string name)
        {
            Name = name;
            Power = 80;
        }
        public override string Name { get; set; }

        public override int Power { get; set; }

        public override string CastAbility()
        {
            return String.Format(GlobalConstants.Hero_Damage_Msg, GetType().Name, Name, Power);
        }
    }
}
