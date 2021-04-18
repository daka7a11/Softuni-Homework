using System;
using System.Linq;
using System.Text;

namespace _3._Treasure_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] keys = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            string input = string.Empty;
            while ((input = Console.ReadLine()).ToLower() != "find")
            {
                StringBuilder decryptMessage = new StringBuilder();
                int keyCount = -1;
                for (int i = 0; i < input.Length; i++)
                {
                    char currDigit = input[i];
                    if (keyCount >= keys.Length - 1)
                    {
                        keyCount = -1;
                    }
                    keyCount++;
                    currDigit -= (char)keys[keyCount];
                    decryptMessage.Append(currDigit);
                }
                string type = string.Empty;
                string coordinates = string.Empty;
                bool isTypeFound = false;
                bool isCoordinatesFound = false;
                int count = 0;
                for (int i = 0; i < decryptMessage.Length; i++)
                {
                    char currDigit = decryptMessage[i];
                    if (currDigit == '&' && count == 0)
                    {
                        count++;
                        isTypeFound = true;
                        continue;
                    }
                    if (currDigit == '&' && count == 1)
                    {
                        count++;
                        isTypeFound = false;
                        continue;
                    }
                    if (isTypeFound)
                    {
                    type += currDigit;
                    }
                    if (currDigit == '<')
                    {
                        isCoordinatesFound = true;
                        continue;
                    }
                    if (currDigit == '>')
                    {
                        isCoordinatesFound = false;
                        continue;
                    }
                    if (isCoordinatesFound)
                    {
                    coordinates += currDigit;
                    }
                }
                Console.WriteLine($"Found {type} at {coordinates}");
            }
        }
    }
}
