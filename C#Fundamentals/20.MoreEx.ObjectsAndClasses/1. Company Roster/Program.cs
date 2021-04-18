using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Company_Roster
{
    public class Employee
    {
        public Employee(string name,double salary,string department)
        {
            this.Name = name;
            this.Salary = salary;
            this.Department = department;
        }
        public string Name { get; set; }
        public double Salary { get; set; }
        public string Department { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Employee> employees = new List<Employee>(n);
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Employee currEmployee = new Employee(input[0],double.Parse(input[1]),input[2]);
                employees.Add(currEmployee);
            }
            string nameOfHighestAvgSalaryDepartment = string.Empty;
            double avgHighestSalary = 0;
            for (int i = 0; i < n; i++)
            {
                string currName = employees[i].Department;
                double currAvgSalary = employees[i].Salary;
                int currEmployeersInOneDepartmentCount = 1;
                for (int j = 0; j < n; j++)
                {
                    if (i==j)
                    {
                        continue;
                    }
                    if (employees[i].Department==employees[j].Department)
                    {
                        currAvgSalary += employees[j].Salary;
                        currEmployeersInOneDepartmentCount++;
                    }
                }
                currAvgSalary /= currEmployeersInOneDepartmentCount;
                if (currAvgSalary>avgHighestSalary)
                {
                    nameOfHighestAvgSalaryDepartment = currName;
                    avgHighestSalary = currAvgSalary;
                }
            }
            employees = employees.OrderBy(x => x.Salary).Reverse().ToList();
            Console.WriteLine($"Highest Average Salary: {nameOfHighestAvgSalaryDepartment}");
            foreach (Employee x in employees)
            {
                if (x.Department==nameOfHighestAvgSalaryDepartment)
                {
                    Console.WriteLine($"{x.Name} {x.Salary:F2}");
                }
            }
        }
    }
}
