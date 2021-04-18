using System;

namespace _1._Extract_Person_Information
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string name = string.Empty;
                string age = string.Empty;
                string input = Console.ReadLine();
                bool isNameFound = false;
                bool isAgeFound = false;
                for (int j = 0; j < input.Length; j++)
                {
                    char currChar = input[j];
                    if (currChar=='|')
                    {
                        isNameFound = false;
                        continue;
                    }
                    if (currChar=='@')
                    {
                        isNameFound = true;
                        continue;
                    }
                    if (currChar=='*')
                    {
                        isAgeFound = false;
                        continue;
                    }
                    if (currChar == '#')
                    {
                        isAgeFound = true;
                        continue;
                    }
                    if (isNameFound)
                    {
                        name += currChar;
                    }
                    if (isAgeFound)
                    {
                        age += currChar;
                    }
                }
                Console.WriteLine($"{name} is {age} years old.");
            }
        }
    }
}
