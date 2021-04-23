using System;
using System.Collections.Generic;
using System.Linq;
namespace _8._Balanced_Parentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();
            Stack<char> openStack = new Stack<char>();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(' || input[i] == '{' || input[i] == '[')
                {
                    openStack.Push(input[i]);
                }
                else
                {
                    char close = input[i];
                    char lastBracket = openStack.Pop();
                    if (!((lastBracket == '(' && close == ')')
                        || (lastBracket == '{' && close == '}')
                        || (lastBracket == '[' && close == ']')))
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
            }
            if (openStack.Count==0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}