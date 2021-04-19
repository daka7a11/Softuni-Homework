using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _3._Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split().Reverse().ToArray();
            Stack<string> stack = new Stack<string>(input);
            int sum = 0;
            while (stack.Count>1)
            {
                int firstNumber = int.Parse(stack.Pop());
                string command = stack.Pop();
                int secondNumber = int.Parse(stack.Pop());
                if (command == "+")
                {
                    sum = firstNumber + secondNumber;
                }
                else
                {
                    sum = firstNumber - secondNumber;
                }
                stack.Push(sum.ToString());
            }
            Console.WriteLine(sum);
        }
    }
}
