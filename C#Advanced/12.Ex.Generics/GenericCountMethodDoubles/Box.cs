using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCountMethodDoubles
{
    public class Box<T> where T: IComparable
    {
        private List<T> list;
        public Box(List<T> list)
        {
            this.list = list;
        }
        public List<T> Swap(int firstIndex, int secondIndex)
        {
            T firstElement = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = firstElement;
            return list;
        }

        public int CountOfGreaterValues(T value)
        {
            int count = 0;

            foreach (var item in list)
            {
                if (item.CompareTo(value) > 0)
                {
                    count++;
                }
            }

            return count;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in list)
            {
                sb.AppendLine($"{item.GetType()}: {item}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
