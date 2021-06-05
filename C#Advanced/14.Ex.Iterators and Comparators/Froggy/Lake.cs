using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Froggy
{
    public class Lake : IEnumerable<int>
    {
        public Lake(List<int> numbers)
        {
            StoneNumbers = numbers;
        }
        public List<int> StoneNumbers { get; set; }

        public List<int> GetFrogPath()
        {
            List<int> path = new List<int>();
            for (int i = 0; i < StoneNumbers.Count; i+=2)
            {
                path.Add(StoneNumbers[i]);
            }
            for (int i = StoneNumbers.Count-1; i >= 0; i--)
            {
                if (i%2!=0)
                {
                    path.Add(StoneNumbers[i]);
                }
            }
            return path;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < StoneNumbers.Count; i++)
            {
                yield return StoneNumbers[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < StoneNumbers.Count; i++)
            {
                yield return StoneNumbers[i];
            }
        }
    }
}
