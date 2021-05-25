using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        public Family()
        {
            Persons = new List<Person>();
        }
        public List<Person> Persons { get; set; }

        public void AddMember(Person member)
        {
            Persons.Add(member);
        }
        public Person GetOldestMember()
        {
            return  Persons.OrderByDescending(x => x.Age).FirstOrDefault();
        }
    }
}
