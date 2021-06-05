using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        private const int INITIAL_CAPACITY = 8;
        private T[] elements;
        private int index = 0;
        public Stack()
        {
            elements = new T[INITIAL_CAPACITY];
        }

        private void Resize()
        {
            T[] copy = new T[elements.Length * 2];
            for (int i = 0; i <= index; i++)
            {
                copy[i] = elements[i];
            }
            elements = copy;
        }

        private void ShiftToLeft()
        {
            for (int i = 0; i < index; i++)
            {
                elements[i] = elements[i + 1];
            }
            elements[index] = default;
        }

        private void ShiftToRight()
        {
            if (index + 1 == elements.Length)
            {
                Resize();
            }
            for (int i = index; i > 0; i--)
            {
                elements[i] = elements[i - 1];
            }
        }

        public void Push(params T[] inputElements)
        {
            foreach (var item in inputElements)
            {
                ShiftToRight();
                elements[0] = item;
                index++;
            }
        }

        public T Pop()
        {
            T result = default;
            if (index-1 < 0)
            {
                Console.WriteLine("No elements");
            }
            else
            {
                index--;
                result = elements[0];
                ShiftToLeft();
            }
            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < index; i++)
            {
                yield return elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < index; i++)
            {
                yield return elements[i];
            }
        }
    }
}
