using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Collection
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private int index = 0;
        public ListyIterator()
        {
            Elements = new List<T>();
        }
        public ListyIterator(List<T> elements)
        {
            Elements = elements;
        }
        public List<T> Elements { get; set; }

        public bool Move()
        {
            if (index + 1 == Elements.Count)
            {
                return false;
            }
            index++;
            return true;
        }

        public bool HasNext()
        {
            if (index + 1 < Elements.Count)
            {
                return true;
            }
            return false;
        }

        public void Print()
        {
            if (index >= 0 && index < Elements.Count)
            {
                Console.WriteLine(Elements[index]);
            }
            else
            {
                Console.WriteLine("Invalid Operation!");
            }
        }

        public void Create(params ListyIterator<T>[] listyIterators)
        {
            ListyIterator<T>[] arr = new ListyIterator<T>[listyIterators.Length];
            if (listyIterators.Length == 0)
            {
                return;
            }
            for (int i = 0; i < listyIterators.Length; i++)
            {
                arr[i] = listyIterators[i];
            }
        }

        public void PrintAll()
        {
            StringBuilder result = new StringBuilder();
            foreach (var element in Elements)
            {
                result.Append($"{element} ");
            }
            Console.WriteLine(result.ToString().TrimEnd());
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Elements.Count; i++)
            {
                yield return Elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < Elements.Count; i++)
            {
                yield return Elements[i];
            }
        }
    }
}
