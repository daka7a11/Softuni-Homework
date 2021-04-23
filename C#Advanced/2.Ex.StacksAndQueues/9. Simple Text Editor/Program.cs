using System;
using System.Collections.Generic;
using System.Linq;
namespace _8._Balanced_Parentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<string> stack = new Stack<string>();
            string text = string.Empty;
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                char command = input.First();
                string actions = string.Empty;
                if (input.Length > 1)
                {
                    actions = input.Substring(2).Replace(" ", "");
                }
                if (command == '1')
                {
                    stack.Push(text);
                    text += actions;
                }
                else if (command == '2')
                {
                    stack.Push(text);
                    int elementsToRemove = int.Parse(actions);
                    text = text.Substring(0, text.Length - elementsToRemove);

                }
                else if (command == '3')
                {
                    int index = int.Parse(actions);
                    Console.WriteLine(text[index - 1]);
                }
                else if (command == '4')
                {
                    if (stack.Count > 0)
                    {
                        text = stack.Pop();
                    }
                    else
                    {
                        text = string.Empty;
                    }
                }
            }
        }
    }
}
