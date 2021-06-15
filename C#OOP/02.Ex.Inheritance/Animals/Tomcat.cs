using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Tomcat : Cat
    {
        public const string defaultGender = "Male";
        public Tomcat(string name, int age, string gender) : base(name, age, defaultGender)
        {

        }
        public Tomcat(string name, int age) : base(name, age, defaultGender)
        {

        }
        public override string ProduceSound()
        {
            return $"MEOW";
        }
    }
}
