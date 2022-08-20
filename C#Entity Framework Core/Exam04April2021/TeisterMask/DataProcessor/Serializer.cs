namespace TeisterMask.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            //StringBuilder sb = new StringBuilder();

            //XmlSerializer serializer = new XmlSerializer(typeof(ExportProjectDTO[]), new XmlRootAttribute("Projects"));

            //var projects = context.Projects
            //     .Where(p => p.Tasks.Count > 0)
            //     .AsEnumerable()
            //     .Select(p => new ExportProjectDTO()
            //     {
            //         ProjectName = p.Name,
            //         HasEndDate = p.DueDate == null ? "No" : "Yes",
            //         TasksCount = p.Tasks.Count,
            //         Tasks = p.Tasks
            //                  .ToArray()
            //                  .Select(t => new ExportProjectTasksDTO()
            //                  {
            //                      Name = t.Name,
            //                      Label = t.LabelType.ToString()
            //                  }).OrderBy(t => t.Name)
            //                  .ToArray()
            //     }).OrderByDescending(p => p.TasksCount)
            //     .ThenBy(p => p.ProjectName)
            //     .ToArray();

            //using (StringWriter writer = new StringWriter(sb))
            //{
            //    XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            //    namespaces.Add(string.Empty, string.Empty);

            //    serializer.Serialize(writer, projects, namespaces);
            //}

            //return sb.ToString().TrimEnd();
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            //var employees = context.Employees
            //   .Where(e => e.EmployeesTasks
            //                .Any(et => et.Task.OpenDate >= date))
            //   .ToArray()
            //   .Select(e => new ExportEmployeeDTO()
            //   {
            //       Username = e.Username,
            //       Tasks = e.EmployeesTasks
            //                .Where(et => et.Task.OpenDate >= date)
            //                .ToArray()
            //                .Select(et => new ExportEmployeeTasksDTO()
            //                {
            //                    TaskName = et.Task.Name,
            //                    OpenDate = et.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
            //                    DueDate = et.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
            //                    LabelType = et.Task.LabelType.ToString(),
            //                    ExecutionType = et.Task.ExecutionType.ToString()
            //                })
            //                .OrderByDescending(t => t.DueDate)
            //                .ThenBy(t => t.TaskName)
            //                .ToArray()
            //   })
            //   .Take(10)
            //   .OrderByDescending(e => e.Tasks.Length)
            //   .ThenBy(e => e.Username)
            //   .ToArray();

            //var json = JsonConvert.SerializeObject(employees, Formatting.Indented);

            //return json;
        }
    }
}