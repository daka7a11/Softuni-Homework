using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.__Student_Academy
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());
                if (!students.ContainsKey(name))
                {
                    students.Add(name,new List<double> {grade});
                }
                else
                {
                    students[name].Add(grade);
                }
            }
            foreach (var x in students)
            {
                double avgGrade = x.Value.Sum();
                avgGrade /= x.Value.Count;
                x.Value.Clear();
                x.Value.Add(avgGrade);
            }
            foreach (var x in students.OrderByDescending(x => x.Value[0]).Where(x => x.Value[0]>=4.50))
            {
                Console.WriteLine($"{x.Key} -> {x.Value[0]:F2}");
            }
        }
    }
}
