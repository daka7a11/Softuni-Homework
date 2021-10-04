using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext db = new SoftUniContext();
            Console.WriteLine(IncreaseSalaries(db));
        }
        //Problem 03
        public static string GetEmployeesFullInformation(SoftUniContext db)
        {
            StringBuilder sb = new StringBuilder();

            var employees = db.Employees
                .OrderBy(x => x.EmployeeId)
                .ToList();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 04
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext db)
        {
            StringBuilder sb = new StringBuilder();

            var employees = db.Employees
                .Where(x => x.Salary > 50000)
                .Select(x => new
                {
                    x.FirstName,
                    x.Salary
                })
                .OrderBy(x => x.FirstName)
                .ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 05
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext db)
        {
            StringBuilder sb = new StringBuilder();

            var employees = db.Employees
                .Where(x => x.Department.Name == "Research and Development")
                .OrderBy(x => x.Salary)
                .ThenByDescending(x => x.FirstName)
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    DepartmentName = x.Department.Name,
                    x.Salary
                })
                .ToList();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} from {e.DepartmentName} - ${e.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 06
        public static string AddNewAddressToEmployee(SoftUniContext db)
        {
            StringBuilder sb = new StringBuilder();
            Address address = new Address() { AddressText = "Vitoshka 15", TownId = 4, };
            db.Addresses.Add(address);
            var employee = db.Employees.First(x => x.LastName == "Nakov");
            employee.Address = address;

            db.SaveChanges();

            var addresses = db.Employees
                .OrderByDescending(x => x.AddressId)
                .Take(10)
                .Select(x => x.Address)
                .ToList();

            foreach (var a in addresses)
            {
                sb.AppendLine(a.AddressText);
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 07
        public static string GetEmployeesInPeriod(SoftUniContext db)
        {
            StringBuilder sb = new StringBuilder();

            var employees = db.Employees
                .Where(x => x.EmployeesProjects.Any(ep => ep.Project.StartDate.Year >= 2001
                                                       && ep.Project.StartDate.Year <= 2003))
                .Take(10)
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    ManagerFirstName = x.Manager.FirstName,
                    ManagerLastName = x.Manager.LastName,
                    Projects = x.EmployeesProjects
                                .Select(ep => new
                                {
                                    ProjectName = ep.Project.Name,
                                    StartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                                    EndDate = ep.Project.EndDate.HasValue ?
                                        ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) :
                                        "not finished"
                                })
                                .ToList()
                })
                .ToList();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.ManagerFirstName} {e.ManagerLastName}");
                foreach (var p in e.Projects)
                {
                    sb.AppendLine($"--{p.ProjectName} - {p.StartDate} - {p.EndDate}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 08
        public static string GetAddressesByTown(SoftUniContext db)
        {
            StringBuilder sb = new StringBuilder();

            var adresses = db.Addresses
                .OrderByDescending(x => x.Employees.Count)
                .ThenBy(x => x.Town.Name)
                .ThenBy(x => x.AddressText)
                .Take(10)
                .Select(x => new
                {
                    x.AddressText,
                    TownName = x.Town.Name,
                    EmployeeCount = x.Employees.Count
                })
                .ToList();

            foreach (var a in adresses)
            {
                sb.AppendLine($"{a.AddressText}, {a.TownName} - {a.EmployeeCount} employees");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 09
        public static string GetEmployee147(SoftUniContext db)
        {
            StringBuilder sb = new StringBuilder();

            var employee = db.Employees
                .Where(x => x.EmployeeId == 147)
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.JobTitle,
                    Projects = x.EmployeesProjects
                                .Select(x => x.Project.Name)
                                .OrderBy(x => x)
                                .ToList()
                })
                .First();

            sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
            foreach (var pName in employee.Projects)
            {
                sb.AppendLine(pName);
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 10
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext db)
        {
            StringBuilder sb = new StringBuilder();

            var departments = db.Departments
                .Where(x => x.Employees.Count > 5)
                .OrderBy(x => x.Employees.Count)
                .ThenBy(x => x.Name)
                .Select(x => new
                {
                    DepartmentName = x.Name,
                    ManagerFirstName = x.Manager.FirstName,
                    ManagerLastName = x.Manager.LastName,
                    Employees = x.Employees
                                 .Select(e => new
                                 {
                                     e.FirstName,
                                     e.LastName,
                                     e.JobTitle
                                 })
                                 .OrderBy(e => e.FirstName)
                                 .ThenBy(e => e.LastName)
                                 .ToList()
                })
                .ToList();

            foreach (var d in departments)
            {
                sb.AppendLine($"{d.DepartmentName} - {d.ManagerFirstName}  {d.ManagerLastName}");
                foreach (var e in d.Employees)
                {
                    sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 11
        public static string GetLatestProjects(SoftUniContext db)
        {
            StringBuilder sb = new StringBuilder();

            var projects = db.Projects
                             .OrderByDescending(x => x.StartDate)
                             .Take(10)
                             .OrderBy(x => x.Name)
                             .Select(x => new
                             {
                                 x.Name,
                                 x.Description,
                                 StartDate = x.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                             })
                             .ToList();

            foreach (var p in projects)
            {
                sb.AppendLine(p.Name);
                sb.AppendLine(p.Description);
                sb.AppendLine(p.StartDate);
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 12
        public static string IncreaseSalaries(SoftUniContext db)
        {
            StringBuilder sb = new StringBuilder();

            var employees = db.Employees
                              .Where(x => x.Department.Name == "Engineering"
                                       || x.Department.Name == "Tool Design"
                                       || x.Department.Name == "Marketing"
                                       || x.Department.Name == "Information Services")
                              .OrderBy(x => x.FirstName)
                              .ThenBy(x => x.LastName);
            foreach (var e in employees)
            {
                e.Salary *= 1.12M;
                sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:F2})");
            }

            db.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        //Problem 13
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext db)
        {
            StringBuilder sb = new StringBuilder();

            var employees = db.Employees
                              .Where(x => x.FirstName.StartsWith("Sa"))
                              .Select(x => new
                              {
                                  x.FirstName,
                                  x.LastName,
                                  x.JobTitle,
                                  x.Salary
                              })
                              .OrderBy(x => x.FirstName)
                              .ThenBy(x => x.LastName)
                              .ToList();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 14
        public static string DeleteProjectById(SoftUniContext db)
        {
            StringBuilder sb = new StringBuilder();

            var project = db.Projects
                            .Where(x => x.ProjectId == 2)
                            .First();

            var eps = db.EmployeesProjects
                       .Where(x => x.ProjectId == project.ProjectId);
            foreach (var ep in eps)
            {
                db.EmployeesProjects.Remove(ep);
            }

            db.Projects.Remove(project);

            db.SaveChanges();

            var projects = db.Projects.Select(x => x.Name).Take(10);

            foreach (var pName in projects)
            {
                sb.AppendLine(pName);
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 15
        public static string RemoveTown(SoftUniContext db)
        {
            var town = db.Towns.Where(x => x.Name == "Seattle").First();

            var addresses = db.Addresses.Where(x => x.TownId == town.TownId).ToList();

            foreach (var a in addresses)
            {
                var employees = db.Employees.Where(x => x.AddressId == a.AddressId).ToList();

                foreach (var e in employees)
                {
                    e.AddressId = null;
                }
                db.Addresses.Remove(a);
            }

            db.Towns.Remove(town);

            db.SaveChanges();

            return $"{addresses.Count} addresses in {town.Name} were deleted";
        }
    }
}
