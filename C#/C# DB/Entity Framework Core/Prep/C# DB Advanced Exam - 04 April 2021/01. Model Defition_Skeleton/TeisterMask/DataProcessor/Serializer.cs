namespace TeisterMask.DataProcessor
{
    using Data;
    using Microsoft.Data.SqlClient.Server;
    using Newtonsoft.Json;
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;
    using TeisterMask.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            StringBuilder stringBuilder = new StringBuilder();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportProjectDto[]), new XmlRootAttribute("Projects"));

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using StringWriter sw = new StringWriter(stringBuilder);

            ExportProjectDto[] projects = context
                .Projects
                .Where(p => p.Tasks.Any())
                .ToArray()
                .Select(p => new ExportProjectDto()
                {
                    Name = p.Name,
                    HasEndDate = p.DueDate.HasValue ? "Yes" : "No",
                    TasksCount = p.Tasks.Count(),
                    Tasks = p.Tasks.ToArray().Select(t => new ExportTaskDto()
                    {
                        Name = t.Name,
                        Label = t.LabelType.ToString()
                    })
                    .OrderBy(t => t.Name)
                    .ToArray()
                })
                .OrderByDescending(p=>p.TasksCount)
                .ThenBy(p=>p.Name)
                .ToArray();

            xmlSerializer.Serialize(sw, projects, namespaces);

            return stringBuilder.ToString().TrimEnd();
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var employees = context
                .Employees
                .Where(e => e.EmployeesTasks.Any(et => et.Task.OpenDate >= date))
                .ToArray()
                .Select(e => new
                {
                    e.Username,
                    Task = e.EmployeesTasks
                    .Where(et => et.Task.OpenDate>=date)
                    .ToArray()
                    .OrderByDescending(et => et.Task.DueDate)
                    .ThenBy(et => et.Task.Name)
                    .Select(et => new
                    {
                        TaskName = et.Task.Name,
                        OpenDate = et.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                        DueDate = et.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                        LabelType = et.Task.LabelType.ToString(),
                        ExcutionType = et.Task.ExecutionType.ToString(),
                    })
                    .ToArray()
                })
                .OrderByDescending(e=>e.Task.Length)
                .ThenBy(e=>e.Username)
                .Take(10)
                .ToArray();

            return JsonConvert.SerializeObject(employees,Formatting.Indented);
        }
    }
}