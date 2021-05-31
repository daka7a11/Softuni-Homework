using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSwapMethodIntegers
{
    public class Box<T>
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
