using System;

namespace Stack
{
    public class Program
    {
        static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>();
            string[] input = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            while (input[0].ToLower() != "end")
            {
                if (input[0].ToLower() == "push")
                {
                    for (int i = 1; i < input.Length; i++)
                    {
                        stack.Push(input[i]);
                    }
                }
                else if (input[0].ToLower() == "pop")
                {
                    stack.Pop();
                }
                input = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }
            for (int i = 1; i <= 2; i++)
            {
                foreach (var item in stack)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
