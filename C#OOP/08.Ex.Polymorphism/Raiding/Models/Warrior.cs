using System;

namespace Raiding.Models
{
    public class Warrior : BaseHero
    {
        public Warrior(string name)
        {
            Name = name;
            Power = 100;
        }
        public override string Name { get; set; }

        public override int Power { get; set; }

        public override string CastAbility()
        {
            return String.Format(GlobalConstants.Hero_Damage_Msg, GetType().Name, Name, Power);
        }
    }
}
