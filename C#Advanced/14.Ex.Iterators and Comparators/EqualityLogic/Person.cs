using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace EqualityLogic
{
    public class Person : IComparable<Person>
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public int CompareTo(Person other)
        {
            int result = Name.CompareTo(other.Name);
            if (result == 0)
            {
                result = Age.CompareTo(other.Age);
            }
            return result;
        }

        public override bool Equals(object obj)
        {
            Person p = (Person)obj;
            if (p==null)
            {
                return false;
            }
            else
            {
                if (Name == p.Name)
                {
                    if (Age == p.Age)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() + Age.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Name} {Age}";
        }
    }
}
