using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.__SoftUni_Course_Planning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lessons = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            string[] command = Console.ReadLine().Split(":");
            while (command[0].ToLower() != "course start")
            {
                if (command[0].ToLower() == "add")
                {
                    if (!lessons.Contains(command[1]))
                    {
                        lessons.Add(command[1]);
                    }
                }
                else if (command[0].ToLower() == "insert")
                {
                    if (!lessons.Contains(command[1]))
                    {
                        lessons.Insert(int.Parse(command[2]), command[1]);
                    }
                }
                else if (command[0].ToLower() == "remove")
                {
                    if (lessons.Contains(command[1]))
                    {
                        lessons.Remove(command[1]);
                        if (lessons.Contains(command[1] + "-Exercise"))
                        {
                            lessons.Remove(command[1] + "-Exercise");
                        }
                    }
                }
                else if (command[0].ToLower() == "swap")
                {
                    if (lessons.Contains(command[1]) && lessons.Contains(command[2]))
                    {
                        int firstLessonIndex = lessons.IndexOf(command[1]);
                        int secondLessonIndex = lessons.IndexOf(command[2]);
                        lessons[firstLessonIndex] = command[2];
                        lessons[secondLessonIndex] = command[1];

                        if (lessons.Contains(command[1] + "-Exercise"))
                        {
                            string firstExName = command[1] + "-Exercise";
                            lessons.Remove(firstExName);
                            lessons.Insert((lessons.IndexOf(command[1]) + 1), firstExName);
                        }
                        if (lessons.Contains(command[2] + "-Exercise"))
                        {
                            string secondExName = command[2] + "-Exercise";
                            lessons.Remove(secondExName);
                            lessons.Insert((lessons.IndexOf(command[2]) + 1), secondExName);
                        }
                    }
                }
                else if (command[0].ToLower() == "exercise")
                {
                    if (lessons.Contains(command[1]))
                    {
                        if (!lessons.Contains(command[1] + "-Exercise"))
                        {
                            lessons.Insert(lessons.IndexOf(command[1]) + 1, command[1] + "-Exercise");
                        }
                    }
                    else
                    {
                        lessons.Add(command[1]);
                        lessons.Add(command[1] + "-Exercise");
                    }
                }
                command = Console.ReadLine().Split(":");
            }
            for (int i = 0; i < lessons.Count; i++)
            {
                Console.WriteLine(i + 1 + "." + lessons[i]);
            }
        }
    }
}
