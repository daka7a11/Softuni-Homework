
using System.Collections;
using System.Collections.Generic;

namespace MilitaryElite
{
    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, SoldiersCorpsEnum corps) 
            : base(id, firstName, lastName, salary)
        {
            Corps = corps;
        }

        public SoldiersCorpsEnum Corps { get; private set; }
    }
}
