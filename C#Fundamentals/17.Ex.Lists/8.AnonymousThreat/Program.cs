using System;
using System.Collections.Generic;
using System.Linq;

namespace _8.AnonymousThreat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split().ToList();
            string[] commands = Console.ReadLine().Split();
            while (commands[0] != "3:1")
            {
                string mergedWord = string.Empty;
                if (commands[0].ToLower() == "merge")
                {
                    int startIndex = int.Parse(commands[1]);
                    int endIndex = int.Parse(commands[2]);
                    if (startIndex < 0 && (endIndex >= 0 && endIndex <= input.Count - 1))
                    {
                        startIndex = 0;
                    }
                    if (endIndex > input.Count - 1 && (startIndex >= 0 && startIndex <= input.Count - 1))
                    {
                        endIndex = input.Count - 1;
                    }
                    if (startIndex >= 0 && startIndex <= input.Count - 1 && endIndex >= 0 && endIndex <= input.Count - 1)
                    {
                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            mergedWord += input[i];
                        }
                        input.RemoveRange(startIndex, endIndex - startIndex + 1);
                        input.Insert(startIndex, mergedWord);
                    }
                }
                else if (commands[0].ToLower() == "divide")
                {
                    int index = int.Parse(commands[1]);
                    int particions = int.Parse(commands[2]);
                    string word = string.Empty;
                    if (index >= 0 && index <= input.Count - 1)
                    {
                        string currWord = input[index];
                        int part = currWord.Length / particions;
                        int insertIndex = index;
                        input.RemoveAt(index);
                        for (int i = 0, j = 0; i < particions; i++)
                        {
                            if (i + 1 == particions)
                            {
                                input.Insert(insertIndex, currWord.Substring(j, currWord.Length - j));
                            }
                            else
                            {

                                input.Insert(insertIndex, currWord.Substring(j, part));
                                insertIndex++;
                                j += part;
                            }
                        }
                    }
                }
                commands = Console.ReadLine().Split();
            }
            Console.WriteLine(string.Join(" ", input));
        }
    }
}