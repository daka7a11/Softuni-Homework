using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._SoftUni_Exam_Results
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> users = new Dictionary<string, int>();
            Dictionary<string, int> languages = new Dictionary<string, int>();
            string[] input = Console.ReadLine().Split("-");
            while (input[0].ToLower() != "exam finished") // user language points
            {
                if (input.Length == 3)
                {
                    string user = input[0];
                    string language = input[1];
                    int points = int.Parse(input[2]);
                    if (users.ContainsKey(user))
                    {
                        if (users[user] < points)
                        {
                            users[user] = points;
                        }
                    }
                    else
                    {
                        users.Add(user, points);
                    }
                    if (languages.ContainsKey(language))
                    {
                        languages[language]++;
                    }
                    else
                    {
                        languages.Add(language, 1);
                    }
                }
                else if (input.Length == 2 && input[1].ToLower()=="banned")
                {
                    if (users.ContainsKey(input[0]))
                    {
                        users.Remove(input[0]);
                    }
                }
                input = Console.ReadLine().Split("-");
            }
            Console.WriteLine("Results:");
            foreach (var user in users.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{user.Key} | {user.Value}");
            }
            Console.WriteLine("Submissions:");
            foreach (var language in languages.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{language.Key} - {language.Value}");
            }
        }
    }
}
