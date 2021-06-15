using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        private Random rand;
        public RandomList()
        {
            rand = new Random();
        }
        public string RandomString()
        {
            int randIndex = rand.Next(0,this.Count);
            string removedElement = this[randIndex];
            this.RemoveAt(randIndex);
            return removedElement;
        }
    }
}
