using System;

namespace _4._Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int start = int.Parse(input[0]);
            int end = int.Parse(input[1]);
            string command = Console.ReadLine();
            Func<int, bool> funcCommand = GetCommand(command);
            for (int i = start; i <= end; i++)
            {
                if (funcCommand(i))
                {
                    Console.Write(i+" ");
                }
            }
        }
        static Func<int, bool> GetCommand(string command)
        {
            switch (command)
            {
                case "even": return n => n % 2 == 0;
                case "odd": return n => n % 2 != 0;
                default: return null;
            }
        }
    }
}
